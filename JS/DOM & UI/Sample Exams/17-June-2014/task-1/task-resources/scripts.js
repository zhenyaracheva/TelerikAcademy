function createImagesPreviewer(selector, items) {
    var i,
        j,
        len,
        fragment = document.createDocumentFragment(),
        root = document.querySelector(selector),
        leftSide = document.createElement('div'),
        rightSide = document.createElement('div'),
        filter = document.createElement('input'),
        filterTitle = document.createElement('div'),
        listOfItems = document.createElement('ul'),
        li,
        imageLiHeader,
        imageLi,
        selectedTitle,
        selectedImage;


    filterTitle.innerText = 'Filter';



    leftSide.className += 'image-container';
    leftSide.style.width = '75%';
    leftSide.style.float = 'left';
    leftSide.style.display = 'inline-block';
    leftSide.style.textAlign = 'center';

    //var selectedParent = document.createElement('div');
    //selectedParent.className += 'image-container';

    selectedTitle = document.createElement('h3');
    selectedTitle.innerText = items[0].title;
    selectedImage = document.createElement('img');
    selectedImage.src = items[0].url;
    selectedImage.style.width = '450px';

    // if this don't work use var selectedParent = document.createElement('div')
    leftSide.appendChild(selectedTitle);
    leftSide.appendChild(selectedImage);
    //leftSide.appendChild(selectedParent);

    rightSide.className += 'image-container';
    rightSide.style.width = '25%';
    rightSide.style.textAlign = 'center';
    rightSide.style.display = 'inline-block';


    listOfItems.style.listStyleType = 'none';
    listOfItems.style.height = '690px';
    listOfItems.style.overflow = 'scroll';

    listOfItems.addEventListener('click', function (ev) {
        var target = ev.target;
        if (target.tagName === 'IMG') {
            selectedTitle.innerText = target.previousElementSibling.innerText;
            selectedImage.src = target.src;
        }

    }, false);

    listOfItems.addEventListener('mouseover', function (ev) {
        var target = ev.target;
        if (target.tagName === "IMG") {
            target.parentElement.style.backgroundColor = 'grey';
            target.parentElement.style.cursor = 'pointer';
        }

    }, false);

    listOfItems.addEventListener('mouseout', function (ev) {
        var target = ev.target;
        if (target.tagName === "IMG") {
            target.parentElement.style.backgroundColor = '';
        }

    }, false);

    li = document.createElement('li');
    li.className += 'image-container';

    imageLiHeader = document.createElement('h3');
    imageLi = document.createElement('img');
    imageLi.style.width = '80%';

    for (i = 0, len = items.length; i < len; i += 1) {
        var currentItem = items[i];
        var currentLi = li.cloneNode(true);
        var currentImageHeader = imageLiHeader.cloneNode(true);
        var currentImage = imageLi.cloneNode(true);

        currentImageHeader.innerText = currentItem.title;
        currentImage.src = currentItem.url;

        currentLi.appendChild(currentImageHeader);
        currentLi.appendChild(currentImage);

        listOfItems.appendChild(currentLi);
    }

    filter.addEventListener('keyup', function(ev){
        var target = ev.target;

        var liChildren = listOfItems.getElementsByTagName('li');

        for (j = 0, len = liChildren.length; j < len; j += 1) {
            var current = liChildren[j];
            var title = current.firstElementChild.innerText;

           if(title.toLowerCase().indexOf(target.value.toLowerCase())<0){
               current.style.display='none';
           }else{
               current.style.display='block';
           }

        }

    }, false);

    rightSide.appendChild(filterTitle);
    rightSide.appendChild(filter);
    rightSide.appendChild(listOfItems);


    fragment.appendChild(rightSide);
    fragment.appendChild(leftSide);

    root.appendChild(fragment);
}