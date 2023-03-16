const search = document.querySelector(".search");

const toggle = document.querySelector(".search-toggle");

const input = document.querySelector(".search-input");

const container = document.querySelector(".search-container");

const debounceSearch = debounce(drawSearchResault);

search.addEventListener("click", () => search.classList.toggle("hidden"));

toggle.addEventListener("click", () => search.classList.toggle("hidden"));

input.addEventListener("click", e => e.stopPropagation());

input.addEventListener("input", e => {
    debounceSearch(e.target.value);
});

container.addEventListener("click", e => e.stopPropagation());

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
    fetch("/SearchBooks?" + new URLSearchParams({
        search: text,
    }))
    .then(response => response.text())
    .then(text => container.innerHTML = text);
}