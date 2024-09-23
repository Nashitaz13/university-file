$(function () {
    var lastScrollTop = 0, delta = 0;
    $(window).scroll(function (event) {
        var st = $(this).scrollTop();

        if (Math.abs(lastScrollTop - st) <= delta)
            return;

        if (st > lastScrollTop) {
            // downscroll code
            console.log('scroll down');
        } else {
            // upscroll code
            console.log('scroll up');
        }
        lastScrollTop = st;
    });
});