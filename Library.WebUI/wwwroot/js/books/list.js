window.onload = drawList(1);

function drawList(page = 1, sort = "title") {

    let container = document.getElementById("gridContainer");

    fetch("/BooksList?" + new URLSearchParams({
        page: page,
        sort: sort
    }))
    .then(response => response.text())
    .then(text => container.innerHTML = text);

    drawPagination(page);
}

function drawPagination(curpage) {
    
    let pagionationContainer = document.getElementById("paginationList");

    let pageButtons = document.getElementsByClassName("page-link");

    const pagionationList = pagination(curpage, +pagionationContainer.getAttribute('data-pages-amount')).map((btn) => {
        if (btn == curpage) {
            return `
                    <li class="page-item">
                        <p class="page-link active">${btn}</p>
                    </li>
                `;
        }
        return `
                <li class="page-item">
                    <p class="page-link">${btn}</p>
                </li>
            `;
    }).join("");

    pagionationContainer.innerHTML = pagionationList;

    for (let i = 0; i < pageButtons.length; i++) {
        pageButtons.item(i).addEventListener("click", () => drawList(pageButtons.item(i).innerHTML))
    }
}

function pagination(c, m) {
        let current = c,
            last = m,
            delta = 2,
            left = current - delta,
            right = current + delta + 1,
            range = [],
            rangeWithDots = [],
            l;

        for (let i = 1; i <= last; i++) {
            if (i == 1 || i == last || i >= left && i < right) {
                range.push(i);
            }
        }

        for (let i of range) {
            if (l) {
                if (i - l === 2) {
                    rangeWithDots.push(l + 1);
                } else if (i - l !== 1) {
                    rangeWithDots.push('...');
                }
            }
            rangeWithDots.push(i);
            l = i;
        }

        return rangeWithDots;
}