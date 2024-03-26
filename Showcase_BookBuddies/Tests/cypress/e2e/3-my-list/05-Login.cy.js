const url = 'https://localhost:7015';
const userEmail = 'someone@email.com';
const wrongEmail = 'lemail2@lemail.com';
const userPassword = 'P@ssw0rd';
const wrongPassword = 'Password';

context('Logging in', () => {

    beforeEach(() => {
        cy.visit(url);
    })

    // Login using form elements
    it('log-in with right credentials', () => {
        cy.get('#account').within(() => {
            cy.get('[name="Input.Email"]').type(userEmail);
            cy.get('[name="Input.Password"]').type(userPassword);
            cy.get('button[type="submit"]').click();
        })
    });

    // Login should fail
    it('log-in with wrong password', () => {
        cy.get('#account').within(() => {
            cy.get('[name="Input.Email"]').type(userEmail);
            cy.get('[name="Input.Password"]').type(wrongPassword);
            cy.get('button[type="submit"]').click();
        })
        cy.get('[class="text-danger validation-summary-errors"]').should('exist');
    });

    // Login should fail
    it('log-in with wrong email', () => {
        cy.get('#account').within(() => {
            cy.get('[name="Input.Email"]').type(wrongEmail);
            cy.get('[name="Input.Password"]').type(wrongPassword);
            cy.get('button[type="submit"]').click();
        })
        cy.get('[class="text-danger validation-summary-errors"]').should('exist');
    });
});