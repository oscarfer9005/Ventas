var ViewModel = function () {
    var self = this;
    self.books = ko.observableArray();
    self.delete = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.authors = ko.observableArray();
    self.newBook = {
        Author: ko.observable(),
        Genre: ko.observable(),
        Price: ko.observable(),
        Title: ko.observable(),
        Year: ko.observable()
    }

    var booksUri = '/api/Vendedors/';
    var authorsUri = '/api/Ciudad/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllBooks() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.books(data);
        });
    }

    self.getBookDetail = function (item) {
        ajaxHelper(booksUri + item.CODIGO, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.getDelete = function (item) {
        ajaxHelper(booksUri + 'delete/' + item.CODIGO, 'POST').done(function (data) {
            self.books.push(item);
        });

        location.reload();
    }

    function getAuthors() {
        ajaxHelper(authorsUri, 'GET').done(function (data) {
            self.authors(data);
        });
    }


    self.addBook = function (formElement) {
        var book = {
            CODIGO_CIUDAD: self.newBook.Author().CODIGO,
            APELLIDO: self.newBook.Genre(),
            NUMERO_IDENTIFICACION: self.newBook.Price(),
            CODIGO: self.newBook.Title(),
            NOMBRE: self.newBook.Year()
        };

        ajaxHelper(booksUri + 'create', 'POST', book).done(function (item) {
            self.books.push(item);
        });

        location.reload();
    }

    // Fetch the initial data.
    getAllBooks();
    getAuthors();
};

ko.applyBindings(new ViewModel());