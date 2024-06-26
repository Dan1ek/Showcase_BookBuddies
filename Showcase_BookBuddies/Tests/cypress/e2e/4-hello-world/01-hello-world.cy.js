
const url = 'https://localhost:7015';


context('Hello World with Login', () => {
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

    it('bestaat hello-world', () => {
        cy.get('hello-world').should('exist');
    });
});
