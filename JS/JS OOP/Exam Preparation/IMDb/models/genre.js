var imdb = imdb || {};

(function (scope) {

    var id = 0;

    function Genre(name) {
        this.name = name;
        this._movies = [];
        this._id = ++id;
    }

    Genre.prototype.addMovie = function (movie) {
        this._movies.push(movie);
        return this._movies.slice();
    };

    Genre.prototype.deleteMovie = function (movie) {
        var index = this._movies.indexOf(movie);
        if (index > -1) {
            this._movies.splice(index, 1);
        }

        return this._movies.slice();
    };

    Genre.prototype.deleteMovieById = function (id) {
        var index = this._movies.getIndexByParameter('id', id);
        if (index > -1) {
            this._movies.splice(index, 1);
        }

        return this._movies.slice();
    };

    Genre.prototype.getMovies = function () {
        return this._movies;
    };

    scope.getGenre = function (name) {
        return new Genre(name);
    }

}(imdb));