# Module 9 - Debugging Guide

`debug-lab/src/product-list-buggy.component.ts` contains 5 intentional bugs.
Work through them in order using the two tools covered in this module.

## Part A - Chrome DevTools

1. Run the app (`ng serve`) and open `http://localhost:4200` in Chrome.
2. Press `F12` to open DevTools, go to the **Elements** tab, and inspect the
   rendered `<li>` elements for the product list - confirm the DOM matches
   what you expect from `filteredProducts`.
3. Switch to the **Sources** tab. Use `Ctrl+P` (or `Cmd+P`) to open
   `product-list-buggy.component.ts` via its source map.
4. Set a breakpoint on the line inside the `.subscribe()` callback
   (BUG 3's comment). Reload the page and confirm the debugger pauses there.
5. Step over (`F10`) into the filter line and inspect `this.products` in the
   **Scope** panel. This is where you'll notice `filteredProducts` is
   computed once and never recalculated.
6. Click "Next product" repeatedly while watching the **Console** - you
   should see Angular throw a `TypeError` once `selectedIndex` runs past
   the end of the array (BUG 4 / BUG 5).

## Part B - VS Code Debugger

1. Copy `vscode-config/launch.json` into your project's `.vscode/` folder.
2. Start `ng serve` in a terminal.
3. In VS Code, open the Run and Debug panel and launch **"ng serve and
   debug"**. This opens Chrome under VS Code's control.
4. Set a breakpoint directly in the `.ts` file (not the compiled output) on
   the `return this.products[this.selectedIndex];` line.
5. Add a **watch expression**: `this.selectedIndex` and another for
   `this.products.length`.
6. Click "Next product" in the browser until the watch shows
   `selectedIndex >= products.length` - this is the exact moment the bug
   fires, confirming the off-by-one/missing-bounds-check pair (BUG 4/5).

## Part C - Fix and verify

Once you've located all 5 bugs using the steps above, fix them:
- BUG 1: initialize `filteredProducts = []`
- BUG 2: call `this.sub?.unsubscribe()` in `ngOnDestroy`
- BUG 3: recompute the filter whenever `products` changes (e.g. a small
  private method called both in the subscribe callback and after any
  mutation of `products`)
- BUG 4/5: clamp `selectedIndex` in `selectNext()` so it never exceeds
  `products.length - 1`, and/or add a bounds check in the `selectedProduct`
  getter.

Re-run the app and confirm clicking "Next product" past the last item no
longer throws, and the console/Sources panel show no further exceptions.
