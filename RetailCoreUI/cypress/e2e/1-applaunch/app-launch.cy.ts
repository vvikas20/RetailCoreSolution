describe('KCC Customer Portal Application Launch', () => {
    it('passes', () => {
        cy.visit('http://localhost:4200/')
        cy.url().should('eq', 'http://localhost:4200/auth/login');
        cy.contains('Please Sign In Here');
    })
})