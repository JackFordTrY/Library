const titleTag = document.querySelector("#title");

listControlButton = document.querySelector("#list-control");

listControlButton.addEventListener("click", () => {
    if (listControlButton.classList.contains("btn-danger")) {
        deleteFromList()
    }
    else {
        addToList()
    }
});

function addToList() {
    fetch("/addtolist?" + new URLSearchParams({
        title: titleTag.innerHTML
    }))
    .then((response) => {
        if (response.redirected) {
            window.location.href = "/user/login";
            return;
        }
        if (response.ok) {
            notificate("Книгу додано!", true);
        }
        if (response.status == 406) {
            notificate("Книга вже додано!", false);
        }
    });
}

function deleteFromList() {
    fetch("/deletefromlist?" + new URLSearchParams({
        title: titleTag.innerHTML
    }))
    .then((response) => {
        if (response.redirected) {
            window.location.href = "/user/login";
            return;
        }
        if (response.ok) {
            notificate("Книга видалена!", true);
        }
        if (response.status == 406) {
            notificate("Книга вже видалена!", false);
        }
    });
}