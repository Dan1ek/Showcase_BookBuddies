// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class BookListItem extends HTMLElement {
    constructor(bookTitle, bookAuthor) {
        super();
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `
                <div class="book-info">
                    <h2>{bookTitle}</h2>
                    <p>by book1author</p>
                </div>
        `;
    }
}

customElements.define('book-list-item', BookListItem);

class BookList extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `
          <h1>Dit wordt een boekenlijst</h1>
        `;
    }
}

customElements.define('book-list', BookList);