using pLesson_notepad_CL;
using System;

namespace pLesson_notepad
{
    public class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IFileManager _fileManager;
        private readonly IMessageService _messageService;

        private string _currentFilePath;

        public MainPresenter(IMainForm view, IFileManager manager, IMessageService service)
        {
            _view = view;
            _fileManager = manager;
            _messageService = service;

            _view.ShowSymbolCount(0);
            _view.ContentChanged += View_ContentChanged;
            _view.FileOpenClick += View_FileOpenClick;
            _view.FileSaveClick += View_FileSaveClick;
        }

        void View_FileSaveClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_currentFilePath))
            {
                if (!String.IsNullOrEmpty(_view.FilePath))
                    _currentFilePath = _view.FilePath;
                else
                    _messageService.ShowError("Не задано имя файла");
            } 
            try
            {
                string content = _view.Content;
                _fileManager.SaveContent(_currentFilePath, content);
                _messageService.ShowMessage("Файл успешно сохранен");
            } catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        void View_FileOpenClick(object sender, System.EventArgs e)
        {
            try
            {
                string filePath = _view.FilePath;
                bool isExist = _fileManager.IsExist(filePath);
                if (!isExist)
                {
                    _messageService.ShowExclamation("Выбранный файл не существует");
                    return;
                }
                _currentFilePath = filePath;

                string content = _fileManager.GetContent(filePath);
                int count = _fileManager.GetSymbolCount(content);

                _view.Content = content;
                _view.ShowSymbolCount(count);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        void View_ContentChanged(object sender, System.EventArgs e)
        {
            string content = _view.Content;
            int count = _fileManager.GetSymbolCount(content);
            _view.ShowSymbolCount(count);

        }
    }
}
