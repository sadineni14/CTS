# Product Backlog - "DeepSkilling Store" (Sample Project)

Use this backlog as the basis for the estimation and sprint-planning
exercises in this module. It intentionally reuses the Products/Orders
domain from Modules 5-8 so the stories feel connected to work you've
already done.

| # | User Story | Priority |
|---|------------|----------|
| 1 | As a shopper, I want to browse a list of products, so that I can decide what to buy. | High |
| 2 | As a shopper, I want to search products by name, so that I can find items quickly. | High |
| 3 | As a shopper, I want to add a product to my cart, so that I can purchase multiple items at once. | High |
| 4 | As a shopper, I want to apply a discount code at checkout, so that I can save money. | Medium |
| 5 | As an admin, I want to view all orders placed today, so that I can track daily sales. | Medium |
| 6 | As an admin, I want to be notified when stock for a product runs low, so that I can reorder in time. | Low |

## Story 1 in full detail (worked example)

**As a** shopper,
**I want** to browse a list of products,
**so that** I can decide what to buy.

**INVEST check:**
- Independent - doesn't depend on other unbuilt stories
- Negotiable - the exact layout/sorting can be discussed with the team
- Valuable - directly enables the shopper's core goal
- Estimable - the team has built product lists before (Module 8)
- Small - fits comfortably in one sprint
- Testable - see acceptance criteria below

**Acceptance Criteria (Given-When-Then):**
```
Given the product catalog has at least one active product
When a shopper opens the product list page
Then all active products are displayed with name, price, and an image

Given the product catalog has no active products
When a shopper opens the product list page
Then an "no products available" message is displayed instead of an empty page

Given a shopper is on the product list page
When the page is still loading data from the API
Then a loading indicator is shown instead of a blank list
```

## Your turn

Write full user stories (with acceptance criteria in Given-When-Then
format) for backlog items **3** (add to cart) and **4** (discount code),
following the worked example above.
