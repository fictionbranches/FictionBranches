function commentEmphasization() {
    let oldEmphasizedComment = null;
    function emphasizeComment() {
        const a = window.location.hash.substring(1);
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
}

function timestamps() {
    const outputTimestamps = document.getElementsByClassName("output-timestamp");
    const simpleTimestamps = document.getElementsByClassName("simple-timestamp");

    for (let i = 0; i < outputTimestamps.length; i++) {
        const timestamp = outputTimestamps.item(i);
        const date = new Date(+(timestamp.dataset.unixtimemillis));
        timestamp.innerText = date.toLocaleDateString() + " " + date.toLocaleTimeString() + " " + date.toLocaleTimeString('en-us',{timeZoneName:'short'}).split(' ')[2];
    }

    for (let i = 0; i < simpleTimestamps.length; i++) {
        const timestamp = simpleTimestamps.item(i);
        timestamp.innerText = new Date(+(timestamp.dataset.unixtimemillis)).toLocaleDateString();
    }
}

function enableTooltips() {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));
    console.log(`Enabled ${tooltipList.length} tooltips`);
}

document.addEventListener('DOMContentLoaded', () => {
    commentEmphasization();
    timestamps();
    enableTooltips();
});