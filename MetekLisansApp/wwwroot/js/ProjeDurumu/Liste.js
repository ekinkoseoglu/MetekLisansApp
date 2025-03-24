document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('searchInput');
    const tableBody = document.getElementById('tableBody');
    const rows = Array.from(tableBody.getElementsByTagName('tr'));
    const noResults = document.getElementById('noResults');
    const pagination = document.getElementById('pagination');

    let currentPage = 1;
    const itemsPerPage = 10;
    let filteredData = [];

    function initialize() {
        filteredData = rows;
        updateTable();
    }

    function filterTable() {
        const filter = searchInput.value.toLowerCase();
        filteredData = rows.filter(row => {
            const firmName = row.cells[1].textContent.toLowerCase();
            return firmName.includes(filter);
        });

        currentPage = 1;
        updateTable();
    }

    function updateTable() {
        rows.forEach(row => row.style.display = 'none');

        const start = (currentPage - 1) * itemsPerPage;
        const end = start + itemsPerPage;
        const paginatedItems = filteredData.slice(start, end);

        paginatedItems.forEach(row => row.style.display = '');

        noResults.style.display = filteredData.length > 0 ? 'none' : 'block';
        updatePagination();
    }

    function updatePagination() {
        const totalPages = Math.ceil(filteredData.length / itemsPerPage);
        pagination.innerHTML = '';

        pagination.appendChild(createPageItem('←', currentPage > 1 ? currentPage - 1 : null));

        for (let i = 1; i <= totalPages; i++) {
            pagination.appendChild(createPageItem(i, i));
        }

        pagination.appendChild(createPageItem('→', currentPage < totalPages ? currentPage + 1 : null));
    }

    function createPageItem(text, page) {
        const li = document.createElement('li');
        li.className = 'page-item';

        const a = document.createElement('a');
        a.className = 'page-link' + (page === currentPage ? ' active' : '');
        a.href = '#';
        a.innerHTML = text;

        if (page) {
            a.addEventListener('click', (e) => {
                e.preventDefault();
                currentPage = page;
                updateTable();
            });
        } else {
            a.classList.add('disabled');
        }

        li.appendChild(a);
        return li;
    }

    searchInput.addEventListener('input', filterTable);
    initialize();
});