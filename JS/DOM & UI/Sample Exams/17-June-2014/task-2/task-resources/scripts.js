/* globals $ */
$.fn.gallery = function (columns) {
    columns = columns || 4;
    var $this = this;
    var $selected = $this.children('.selected');
    var $galleryList = $this.children('.gallery-list');
    var $imageContainers = $galleryList.children('.image-container');

    var $prevImage = $selected.find('#previous-image');
    var $nextImage = $selected.find('#next-image');
    var $currentImage = $selected.find('#current-image');


    $imageContainers.each(function (index, element) {
        if (index % columns == 0) {
            $(element).addClass('clearfix');
        }
    });

    $galleryList.on('click', 'img', function () {
        var $this = $(this);

        // blurred background
        $galleryList.addClass('blurred');
        //disable background:
        $('<div />').addClass('disabled-background').appendTo($galleryList);
        applySelected($this);
        $selected.show();

    });

    $currentImage.on('click', function () {
        $selected.hide();
        // add blurred background
        $galleryList.removeClass('blurred');
        // remove disabling-background
        $galleryList.children('.disabled-background').remove();
    });

    $prevImage.on('click', function () {
        var $this = $(this);
        applySelected($this);
    });

    $nextImage.on('click', function () {
        var $this = $(this);
        applySelected($this);
    });

    function applySelected($element) {
        var currentImageInfo = getImageInformation($element);
        setImageInformation($currentImage, currentImageInfo.src, currentImageInfo.index);

        var prevIndex = getPreviuosIndex(currentImageInfo.index);
        var prevImage = getImageByIndex(prevIndex);
        var previousImageInfo = getImageInformation(prevImage);
        setImageInformation($prevImage, previousImageInfo.src, previousImageInfo.index);

        var nextIndex = getNextIndex(currentImageInfo.index);
        var nextImage = getImageByIndex(nextIndex);
        var nextImageInfo = getImageInformation(nextImage);
        setImageInformation($nextImage, nextImageInfo.src, nextImageInfo.index);
    }

    function getImageByIndex(index) {
        return $('.gallery').find('img[data-info="' + index + '"]');
    }

    function getImageInformation($element) {
        return {
            src: $element.attr('src'),
            index: parseInt($element.attr('data-info'))
        }
    }

    function setImageInformation($element, src, index) {
        $element.attr('src', src);
        $element.attr('data-info', index);
    }

    function getNextIndex(index) {
        index += 1;
        if (index > $imageContainers.length) {
            index = 1;
        }
        return index;
    }

    function getPreviuosIndex(index) {
        index -= 1;

        if (index < 1) {
            index = $imageContainers.length;
        }

        return index
    }

    $this.addClass('gallery');
    $selected.hide();

    return this
};