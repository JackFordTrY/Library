let curPage = 1;
let isAvailable = false

let gridContainer;

const gridWrap = document.getElementById("gridwrap");

window.onload = loadList();


function loadList() {


    if (curPage == 1) {
        let loader =
        `
            <span class="loader"></span>
        `;

        gridWrap.innerHTML = loader;
    }


    fetch("/list?" + new URLSearchParams({
        page: curPage
    }))
    .then(response => response.json())
    .then(data => {
        gridWrap.innerHTML = 
        `
            <div class="grid-container" id="gridcontainer"></div>
        `;
        if (data.hasNextPage) {
            curPage++;
        }
        gridContainer = document.getElementById("gridcontainer")
        updateList(data.books)
    });
};

window.addEventListener("scroll", () => {
    console.log("scroll");

    if (window.scrollY + window.innerHeight >= document.body.offsetHeight * 0.9
        && !isAvailable
    )
    {
        isAvailable = !isAvailable;

        fetch("/list?" + new URLSearchParams({
            page: curPage
        }))
        .then(response => response.json())
        .then(data => {
            if (data.hasNextPage) {
                curPage++;
                isAvailable = !isAvailable;
            }
            updateList(data.books);
        });
    }
});

function updateList(books){

    const booksHtml = books.map(b =>
        `
            <div class="grid-item">
                <a href="/${b.title.toLowerCase()}"><img src="${b.cover}" height="141" width="87" alt="${b.title}"></a>
                <br>
                <a class="grid-item-text-link" href="/${b.title.toLowerCase()}" aria-label="${b.title}">${b.title}</a>
                <br>
                <p style="color:black;">${b.date}</p>
            </div>
    `).join('');

    gridContainer.innerHTML += booksHtml;    
}