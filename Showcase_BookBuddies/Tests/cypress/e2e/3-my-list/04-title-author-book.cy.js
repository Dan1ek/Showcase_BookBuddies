const url = 'https://localhost:7015';


describe('Check for book title and author', () => {

    const userEmail = 'someone@gmail.com';
    const userPassword = 'P@ssw0rd';

    beforeEach(() => {
        cy.visit(url);

        // Login using form elements
        cy.get('#account').within(() => {
            cy.get('[name="Input.Email"]').type(userEmail);
            cy.get('[name="Input.Password"]').type(userPassword);
            cy.get('button[type="submit"]').click();
        });
    });

    it('shows book title and author', () => {

        // Check if signed in
        cy.get('.text-center').should('contain', 'Jouw boekenlijst')

        // Check for book title
        cy.get('book-s')
            .first()
            .shadow() // Get shadow DOM content
            .find('p')
            .first()
            .should('be.visible')

        // Check for book author
        cy.get('book-s')
            .first()
            .shadow() // Get shadow DOM content
            .find('p')
            .last()
            .should('be.visible')
    })
})
