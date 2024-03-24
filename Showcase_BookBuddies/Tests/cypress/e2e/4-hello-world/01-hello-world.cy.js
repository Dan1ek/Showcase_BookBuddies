const url = 'https://localhost:7015/';

context('Hello World', () => {
    beforeEach(() => {
        cy.visit(url)
    })

    it('bestaat hello-world', () => {
        cy.get('hello-world').should('exist')
    })

});