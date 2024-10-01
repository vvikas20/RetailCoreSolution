describe('KCC Customer Portal Login Functionality', () => {
    it('Login Test Case', () => {
        const usernameInput = '[ng-reflect-name="email"]';
        const passwordInput = '#password';
        const captchaInput = '[ng-reflect-name="captcha"]';
        const signInButton = 'span.p-button-label';

        //'navigates to login and verifies URL'
        cy.visit('http://localhost:4200/auth/login');
        cy.url().should('eq', 'http://localhost:4200/auth/login');

        //'enters username and verifies value'
        cy.get(usernameInput).type('rajat');
        cy.get(usernameInput).should('have.value', 'rajat');

        //'enters password and verifies value (masked)'
        cy.get(passwordInput).type('rajat@123').should($passwordInput => {
            const value = $passwordInput.val();
            expect(value).not.to.equal('rajat@123');
        });

        //'handles captcha (consider mocking or disabling)'
        cy.get(captchaInput).type('BYPASS_CAPTCHA'); // Placeholder for now


        //'clicks Sign In and verifies successful login URL'
        cy.get(signInButton).contains('Continue to Login').click();
        cy.url().should('eq', 'http://localhost:4200/home/dashboard');

    })
});
