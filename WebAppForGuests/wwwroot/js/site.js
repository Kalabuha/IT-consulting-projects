function ready(callback) {
    // in case the document is already rendered
    if (document.readyState != 'loading') callback();
    // modern browsers
    else if (document.addEventListener) document.addEventListener('DOMContentLoaded', callback);
    // IE <= 8
    else document.attachEvent('onreadystatechange', function () {
        if (document.readyState == 'complete') callback();
    });
}

ready(function () {
    let collapseElements = document.querySelectorAll('.collapsable .collapse');
    for (collapse of collapseElements) {
        collapse.onclick = function (event) {
            let collapsable = this.closest('.collapsable');
            let expanded = collapsable.classList.contains('expanded');
            if (expanded) {
                collapsable.classList.remove('expanded');
            } else {
                collapsable.classList.add('expanded');
            }
        }
    }
})
