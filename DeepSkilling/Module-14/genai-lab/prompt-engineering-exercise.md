# Prompt Engineering Exercise

Try each prompt below in GitHub Copilot Chat (or any chat-based AI coding
assistant you have access to) and compare the quality/consistency of the
results across techniques.

## 1. Zero-shot prompting
No examples given - just the direct task.

```
Write a C# method that validates whether a string is a valid email address.
```

**Observe:** Does it use a regex or a built-in library? Does it handle
edge cases (e.g. `null`, empty string) without being asked?

## 2. Few-shot prompting
Give 2-3 examples of the input/output pattern you want before asking for
the real task - this steers style and format more reliably than zero-shot.

```
Convert these method names to their unit test names:

CalculateDiscount -> Test_CalculateDiscount_ReturnsDiscountedPrice
GetProductById -> Test_GetProductById_ReturnsCorrectProduct

Now convert: ValidateEmail
```

**Observe:** Did it follow the exact naming pattern from your examples,
rather than inventing its own convention?

## 3. Chain-of-thought prompting
Ask the model to reason step by step before producing the final answer -
useful for anything involving logic, not just code generation.

```
A product costs $80. A 15% discount is applied, then an 8% sales tax is
added to the discounted price. Think step by step, then write a C# method
`CalculateFinalPrice(decimal price)` that implements this correctly.
```

**Observe:** Compare this to asking for the method directly with no
"think step by step" instruction - does forcing the reasoning step reduce
order-of-operations mistakes (discount before tax vs. tax before discount)?

## 4. Best-practice prompt structure
Rewrite the following vague prompt to be specific about context, desired
output format, and constraints:

> "fix my code"

Your improved version should specify: what language/framework, what the
bug symptom is, what output format you want (e.g. "just the corrected
method, with a one-line explanation of what was wrong"), and any
constraints (e.g. "don't change the method signature").

## Questions to answer
1. Which technique produced the most *consistent* result across repeated
   attempts (chain-of-thought, few-shot, or zero-shot)?
2. What's one piece of information you should never paste into a prompt
   for an AI coding assistant, and why (tie this back to the "Security and
   Ethical Considerations" topics in the handbook)?
3. Why does giving the model examples (few-shot) tend to work better than
   describing the desired format in words alone?
