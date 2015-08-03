/* globals $ */

/*
 Create a function that takes a selector and:
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided ID is not a **jQuery object** or a `string`

 */
function solve() {
    return  function Events(selector) {

        if (typeof(selector) !== 'string' || $(selector).size() === 0) {
            throw 'invalid selector';
        }

        if (typeof selector === 'string') {
            // selector = $('#'+selector); to run in browser
            selector = $(selector);
        }

        var i,
            len,
            $buttons;

        $buttons = selector.children('.button');
        for (i = 0, len = $buttons.length; i < len; i += 1) {
            var $currElement = $($buttons[i]);
            $currElement.text('hide')
                .css('display', '')
                .on('click', ClickedButton);
        }

        function ClickedButton() {
            var $this = $(this);

            var $nextContent = $this.nextAll('.content').first(),
                $nextBtn = $this,
                nextSibling = $this.next();

            if (nextSibling.hasClass('button')) {
                $nextBtn = nextSibling;
            }

            if ($nextBtn.length !== 0 && $nextContent.length !== 0) {

                if ($nextContent[0].style.display === 'none') {
                    $nextContent[0].style.display = '';
                    $nextBtn[0].innerHTML = 'hide';
                } else {
                    $nextContent[0].style.display = 'none';
                    $nextBtn[0].innerHTML = 'show';
                }
            }
        }
    };
};
Events('root');
//module.exports = solve;