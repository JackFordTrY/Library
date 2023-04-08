let currentPage = 1;

let isAvailable = false;

let gridContainer;

const gridWrap = document.querySelector(".grid-wrap");

const filterContainer = document.querySelector(".filter-container");

const dropdownItems = document.querySelectorAll(".dropdown-item");

const applyButton = document.querySelector(".filter-button.apply");

const clearButton = document.querySelector(".filter-button.clear");

const formData = new FormData();

window.onload = loadList();

dropdownItems.forEach(b => b.addEventListener("click", e => e.stopPropagation()));

window.addEventListener("scroll", () => {
    if (window.scrollY + window.innerHeight >= document.body.offsetHeight * 0.85
        && isAvailable
    )
    {
        formData.set("page", currentPage);

        fetchBooks();
    }
});

applyButton.addEventListener("click", (e) => {
    e.preventDefault();

    gridContainer.innerHTML = "";

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

    formData.set("genreFilters", JSON.stringify(genres));

    fetchBooks();
});

function fetchBooks() {
    isAvailable = false;

    fetch("/list", {
        method: "POST",
        body: formData
    })
    .then(response => response.json())
    .then(data => {
        if (data.hasNextPage) {
            currentPage++;
            isAvailable = true;
        }
        updateList(data.books);
    });
}

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
            <div class="grid-container"></div>
        `;
        if (data.hasNextPage) {
            currentPage++;
            isAvailable = true;
        }
        gridContainer = document.querySelector(".grid-container")
        updateList(data.books)
    });
};


function updateList(books) {
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

    gridContainer.innerHTML += booksHtml;
}
