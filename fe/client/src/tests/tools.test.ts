import { formatDate, makeUserNameFromEmail, isPasswordCorrect } from "../tools"


it('formats date correctly', () => {
    const d = new Date('01.02.2022 10:00');
    const formatted = formatDate(d)
    expect(formatted).toBe('02.01.2022 10:00')
})

it('formats username correctly', () => {
    const formatted = makeUserNameFromEmail('userName@mail.com')
    expect(formatted).toBe('userName')
})

// describe('password', ()=> {
//     it('validates length', ()=> {
         
//     })
// })