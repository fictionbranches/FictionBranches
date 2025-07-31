document.addEventListener('DOMContentLoaded', () => {
    
    let oldEmphasizedComment = null;
    function emphasizeComment() {
        let a = window.location.hash.substring(1);
        if (a) {
            if (a.length > 7) {
                if (a.startsWith('comment')) {
                    if (oldEmphasizedComment) {
                        oldEmphasizedComment.classList.remove('emphasizedComment');
                    }

                    let div = document.getElementById(a);
                    if (div) {
                        div.classList.add('emphasizedComment');
                        oldEmphasizedComment = div;
                    }
                }
            }
        }
    }

    window.addEventListener('hashchange', emphasizeComment);

    emphasizeComment();
});