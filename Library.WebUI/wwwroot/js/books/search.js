const search = document.querySelector(".search");

const input = document.querySelector(".search-input");

const searchContainer = document.querySelector(".search-container");

const toggle = document.querySelector("#search-toggle");

const debounceSearch = debounce(drawSearchResault, 600);

search.addEventListener("click", () => search.classList.toggle("hidden"));

toggle.addEventListener("click", () => search.classList.toggle("hidden"));

input.addEventListener("click", e => e.stopPropagation());

input.addEventListener("input", e => {
    debounceSearch(e.target.value);
});

searchContainer.addEventListener("click", e => e.stopPropagation());

function debounce(cb, delay = 1000){
    let timeout;

    return(...args) => {
        clearTimeout(timeout)
        timeout = setTimeout(()=>{
            cb(...args)
        }, delay)
    };
}

function drawSearchResault(text) {
    fetch("/search?" + new URLSearchParams({
        searchstring: text,
    }))
    .then(response => response.json())
    .then(data => {

        if(!data.books || data.books.length < 1){
            searchContainer.innerHTML = 
            `
                <div class="search-item">
                    <p style="margin-bottom: 0;">Nothing was found!</p>
                </div>
            `;
        }
        else {

            searchContainer.innerHTML = data.books.map(b =>{
                return `
                <div class="search-item">
                    <a href="/${b.title.toLowerCase()}" class="search-item-title">${b.title}<span class="search-item-author"> / ${b.authorName}</span></a> <hr>
                </div>
                `
            }).join('');
        }

    });
}