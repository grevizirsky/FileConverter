using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using System;
using System.Linq;

namespace PdfConverter;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public async void OnSelectFileClicked(object? sender, RoutedEventArgs e)
    {
        var storageProvider = this.StorageProvider;

        var filePickerOptions = new FilePickerOpenOptions
        {
            Title = "Selecione o arquivo",
            AllowMultiple = false,
            FileTypeFilter = new[] //Define um filtro de tipos de arquivos que o usuario pode selecionar
            {
                new FilePickerFileType("Documentos de E-book") { Patterns = new[] { "*.pdf", "*.epub" } },
                new FilePickerFileType("Arquivos PDF") { Patterns = new[] { "*.pdf" } },
                new FilePickerFileType("Arquivos EPUB") { Patterns = new[] { "*.epub" } },
            }
        };
        
        var result = await storageProvider.OpenFilePickerAsync(filePickerOptions);

        if (result.Any())
        {
            //Pega o caminho do arquivo (TryGetLocalPath obtem o caminho como uma string)
            string? filePath = result.First().TryGetLocalPath();
            
            //Textbox da UI
            var filePathTextBox = this.FindControl<TextBox>("FilePathTextBox");

            if (filePathTextBox != null && filePath != null)
            {
                filePathTextBox.Text = filePath;
            }
        }


    }
}