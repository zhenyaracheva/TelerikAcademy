function solve() {
    var library = (function () {
        var result,
            books = [],
            categories = [];

        function validation(book) {
            validateBookTitleAndCategory(book.title);
            validateAuthor(book.author);
            validateISBN(book.isbn);
            validateBookTitleAndCategory(book.category);
            isUnique(book);

        }

        function isUnique(book) {
            var i,
                len;

            for (i = 0, len = books.length; i < len; i += 1) {
                if (book.title.toLowerCase() === books[i].title.toLowerCase()) {
                    throw new Error('Book title already exist');
                }

                if (book.isbn === books[i].isbn) {
                    throw new Error('Book ISBN already exist');
                }
            }
        }

        function validateBookTitleAndCategory(title) {
            if (title.length < 2 && title.length > 100) {
                throw  new Error('Invalid book title!');
            }
        }

        function validateAuthor(author) {
            if (author.length === 0) {
                throw  new Error('Book has invalid author');
            }
        }

        function validateISBN(isbn) {
            isbn = isbn.toString();
            if (isbn.length !== 13 && isbn.length !== 10) {
                throw new Error('Invalid book ISBN');
            }
        }

        function listBooks(parameter) {
            var i,
                len,
                booksToReturn = [];

            if (arguments.length > 0) {

                if (typeof parameter.category !== 'undefined') {
                    for (i = 0, len = books.length; i < len; i += 1) {
                        if (books[i].category === parameter.category) {
                            booksToReturn.push(books[i]);
                        }
                    }

                    return booksToReturn;
                }

                if (typeof parameter.author !== 'undefined') {


                    for (i = 0, len = books.length; i < len; i += 1) {
                        if (books[i].author === parameter.author) {
                            booksToReturn.push(books[i]);
                        }
                    }

                    return booksToReturn;
                }
            }

            return books.slice();
        }

        function addBook(book) {

            validation(book);
            book.ID = books.length + 1;
            books.push(book);
            if (categories.indexOf(book.category) === -1) {
                categories.push(book.category);
            }
            return book;
        }

        function listCategories() {
            return categories.slice();
        }

        result = {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };

        return result
    }());
    return library
}