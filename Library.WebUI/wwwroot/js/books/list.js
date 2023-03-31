let currentPage = 1;

let isAvailable = true;

let gridContainer;

const gridWrap = document.getElementById("gridwrap");

const filterContainer = document.querySelector(".filter-container");

const dropdownItems = document.querySelectorAll(".dropdown-item");

const applyButton = document.querySelector(".filter-button.apply");

const formData = new FormData();

window.onload = loadList();

dropdownItems.forEach(b => b.addEventListener("click", e => e.stopPropagation()));

window.addEventListener("scroll", () => {
    if (window.scrollY + window.innerHeight >= document.body.offsetHeight * 0.85
        && isAvailable
    )
    {
        console.log("scroll fired");
        isAvailable = !isAvailable;

        formData.set("page", currentPage);

        fetch("/list", {
            method: "POST",
            body: formData
        })
        .then(response => response.json())
        .then(data => {
            if (data.hasNextPage) {
                currentPage++;
                isAvailable = !isAvailable;
            }
            updateList(data.books);
        });
    }
});

applyButton.addEventListener("click", (e) => {
    e.preventDefault();

    currentPage = 1;

    formData.set("page", currentPage);

    if (document.querySelector("input[name=\"order\"]:checked")) {
        formData.set("order", document.querySelector("input[name=\"order\"]:checked").value);
    }

    if (document.querySelector("input[name=\"direction\"]:checked")) {
        formData.set("direction", document.querySelector("input[name=\"direction\"]:checked").value);
    }

    if (!isNaN(document.querySelector("input[name=\"yearFrom\"]").value)) {
        formData.set("yearFrom", document.querySelector("input[name=\"yearFrom\"]").value);
    }

    if (!isNaN(document.querySelector("input[name=\"yearTo\"]").value)) {
        formData.set("yearTo", document.querySelector("input[name=\"yearTo\"]").value);
    }

    let genres = [];

    document.querySelectorAll("input[name=\"genre\"]:checked").forEach((e)=> genres.push(+e.value));

    if (genres.length > 0) {
        formData.set("genreFilters", JSON.stringify(genres));
    }

    fetch("/list?", {
        method: "POST",
        body: formData
    })
    .then(response => response.json())
    .then(data=>{
        if (data.hasNextPage) {
            currentPage++;
            isAvailable = true;
        }
        updateList(data.books, currentPage - 1 == 1);
    })
});

function loadList() {
    if (currentPage == 1) {
        let loader =
        `
            <span class="loader"></span>
        `;

        gridWrap.innerHTML = loader;
    }

    formData.set("page", currentPage)

    formData.set("order", "Title")

    formData.set("direction", "Ascending")

    fetch("/list?", {
        method: "POST",
        body: formData
    })
    .then(response => response.json())
    .then(data => {
        gridWrap.innerHTML =
        `
            <div class="grid-container" id="gridcontainer"></div>
        `;
        if (data.hasNextPage) {
            currentPage++;
        }
        gridContainer = document.getElementById("gridcontainer")
        updateList(data.books)
    });
};


function updateList(books, rerender = false) {
    const booksHtml = books.map(b =>
        `
            <div class="grid-item">
                <a href="/${b.title.toLowerCase()}"><img src="${b.cover}" height="141" width="87" alt="${b.title}"></a>
                <br>
                <a class="grid-item-text-link" href="/${b.title.toLowerCase()}" aria-label="${b.title}">${b.title}</a>
                <br>
                <p style="color:white;">${b.date}</p>
            </div>
        `
    ).join('');

    if (rerender) {
        gridContainer.innerHTML = booksHtml;
    }
    else {
        gridContainer.innerHTML += booksHtml;
    }
}