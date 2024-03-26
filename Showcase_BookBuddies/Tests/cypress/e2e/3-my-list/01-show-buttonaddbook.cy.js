
const url = 'https://localhost:7015';


describe('Initial Page Load', () => {
    const userEmail = 'someone@gmail.com'; // Replace with your actual email
    const userPassword = 'P@ssw0rd'; // Replace with your actual password

    beforeEach(() => {
        cy.visit(url);

        // Login using form elements
        cy.get('#account').within(() => {
            cy.get('[name="Input.Email"]').type(userEmail);
            cy.get('[name="Input.Password"]').type(userPassword);
            cy.get('button[type="submit"]').click();
        });

    });

        it('should conditionally render add book button and form', () => {
            // Test case for empty book list (no button or form)
            cy.get('#buttonAddBook').should('be.visible');
            cy.get('#add-booklist-form').should('not.exist');
        });
    });



