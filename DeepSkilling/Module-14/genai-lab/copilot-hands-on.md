# GitHub Copilot Hands-On

## Setup
1. Install the GitHub Copilot extension in VS Code and sign in with your
   GitHub account (a free trial or your organization's license should
   cover this).
2. Open any project from the earlier modules (e.g. the Module 5 EF Core
   project) to try Copilot against real, familiar code.

## Exercise 1 - Generate a function from a comment
Create a new file `discount-calculator.cs` and type only this comment,
then press Enter and wait for Copilot's suggestion (accept with `Tab`):

```csharp
// Calculate the final price after applying a percentage discount,
// then adding a percentage sales tax. Round to 2 decimal places.
public decimal CalculateFinalPrice(decimal price, decimal discountPercent, decimal taxPercent)
```

**Check:** Does the generated body match what you'd expect from the
comment? Does it round correctly? Does it handle `discountPercent` or
`taxPercent` being 0?

## Exercise 2 - Generate documentation from code
Take an existing method from Module 5 or 6 (e.g. `ProductRepository`'s
`GetByIdAsync`) and ask Copilot Chat:

```
/doc
```

or type a comment above the method: `// Add XML doc comments explaining
this method`. Compare the generated docs against what the method actually
does - Copilot can be wrong about edge cases, so review before accepting.

## Exercise 3 - Refactor existing code
Select the `product-list-buggy.component.ts` file from Module 9 (before
you fix it) and ask Copilot Chat:

```
Review this component for bugs and suggest fixes, explaining each one.
```

**Compare:** Did Copilot catch all 5 intentional bugs from Module 9's
`debugging-guide.md`? Which ones did it miss, if any? This is a good
illustration of why AI-assisted suggestions still need human review.

## Exercise 4 - Generate test cases
Ask Copilot Chat, referencing an existing method:

```
Write NUnit test cases for CalculateFinalPrice, covering the normal
case, a zero discount, a zero tax, and a negative price.
```

**Check:** Does it use Moq where appropriate? Does it follow the NUnit
`[TestCase]` pattern from Module 4? Do the generated assertions actually
match the method's real behavior, or did it assume behavior that isn't
there?

## Reflection
Write 3-4 sentences on where Copilot saved you the most time in this
exercise, and one place where you had to correct or reject its
suggestion. This maps directly to the module's learning objective on
identifying risks in AI-generated code (security, licensing, correctness)
and using it responsibly rather than accepting suggestions blindly.
