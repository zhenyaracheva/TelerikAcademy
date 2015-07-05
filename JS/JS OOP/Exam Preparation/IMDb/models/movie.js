var imdb = imdb || {};

(function (scope) {

    var id = 0;

    function Movie(title, length, rating, country) {
        this._id = ++id;
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.county = country;
        this._actors = [];
        this._reviews = [];
    }

    Object.defineProperty(Movie.prototype, 'rating', {
        get: function () {
            return this._rating;
        },
        set: function (value) {
            if (value < 1 || value > 10) {
                throw new Error('Movie rating must be between 1 and 10!')
            }

            this._rating = value;
        }
    });

    Movie.prototype.addActor = function (actor) {
        this._actors.push(actor);
        return this._actors.slice();
    };

    Movie.prototype.getActors = function () {
        return this._actors.slice();
    };

    Movie.prototype.addReview = function (review) {
        this._reviews.push(review);
        return this._reviews.slice();
    };

    Movie.prototype.deleteReview = function (review) {
        var index = this._reviews.indexOf(review);
        if (index > -1) {
            this._reviews.splice(index, 1);
        }

        return this._reviews.slice();
    };

    Movie.prototype.deteleReviewById = function (id) {
        var index = this._reviews.getIndexByParameter('id', id);
        if (index > -1) {
            this._reviews.splice(index, 1);
        }

        return this._reviews.slice();
    };

    Movie.prototype.getReviews = function () {
        return this._reviews.slice();
    };

    scope._Movie = Movie;
    scope.getMovie = function (title, length, rating, country) {
        return new Movie(title, length, rating, country);
    }

}(imdb));