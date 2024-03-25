// show book list info component
class BookListComponent extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
    }

    connectedCallback() {
        const listTitle = this.getAttribute('list-title');
        const listDescription = this.getAttribute('list-description');

        const shadowRoot = this.shadowRoot;
        shadowRoot.innerHTML = `
        <h2>${listTitle}</h2>
        <p>${listDescription}</p>
        `;
    }
}

customElements.define('book-list', BookListComponent);

// show books in list component
class BookComponent extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
    }

    connectedCallback() {
        const bookTitle = this.getAttribute('book-title');
        const bookAuthor = this.getAttribute('book-author');

        const shadowRoot = this.shadowRoot;
        shadowRoot.innerHTML = `
        <p>${bookTitle}</p>
        <p>${bookAuthor}</p>
        `;
    }
}

customElements.define('book-s', BookComponent);


// show book list form button
const addFormButton = document.getElementById('buttonAddBook');
if (addFormButton) {
    addFormButton.addEventListener('click', () => {
        addBooksFormVisible();
    });
    function addBooksFormVisible() {
        document.getElementById('add-books-form').style.visibility = "visible";
    }
}



//hello world
class HelloWorld extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `
          <h1>Hello world!</h1>
        `;
    }
}

customElements.define('hello-world', HelloWorld);
