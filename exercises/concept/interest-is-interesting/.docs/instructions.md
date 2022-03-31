# Instructions

In this exercise you'll be working with savings accounts. Each year, the balance of your savings account is updated based on its interest rate. The interest rate your bank gives you depends on the amount of money in your account (its balance):

- 3.213% for a negative balance (results in negative interest).
- 0.5% for a positive balance less than `1000` dollars.
- 1.621% for a positive balance greater or equal than `1000` dollars and less than `5000` dollars.
- 2.475% for a positive balance greater or equal than `5000` dollars.

Each year the government allows you to donate a percentage of your money to charity, tax free. Because you're a nice person, if your balance ends up positive at the end of the year, you take the tax-free percentage and double it, rounding down to the nearest whole dollar.  You don't mind paying tax on the second half of the donation.

You have three tasks, each of which will deal with your balance and its interest rate.

## 1. Calculate the interest rate

Implement the `interestRate` function to calculate the interest rate based on the specified balance:

```fsharp
interestRate 200.75m
// => 0.5f
```

Note that the value returned is a `single`.

## 2. Calculate the interest

Implement the `interest` method to calculate the interest based on the specified balance:

```fsharp
interest 200.75m
// => 1.00375m
```

Note that the value returned is a `decimal`.

## 3. Calculate the annual balance update

Implement the `annualBalanceUpdate` function to calculate the annual balance update, taking into account the interest rate:

```fsharp
annualBalanceUpdate 200.75m
// => 201.75375m
```

Note that the value returned is a `decimal`.

## 4. Calculate how much money to donate

Implement the `amountToDonate` function to calculate how much money to donate to charities based on the balance and the tax-free percentage that the government allows:

```fsharp
let balance = 550.5m
let taxFreePercentage = 2.5
amountToDonate balance taxFreePercentage
// => 27
```

Note that the value returned is an `int`.
