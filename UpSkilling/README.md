# upskilling

# 🏙️ Local Community Event Portal
### Cognizant Upskilling Project — Complete Exercise Submission

---

## 📁 Project Structure

```
community-portal/
├── README.md                          ← You are here
├── html5/
│   └── index.html                     ← All 10 HTML5 Exercises
├── css3/
│   ├── index.html                     ← All 11 CSS3 Exercises (demo page)
│   └── styles.css                     ← External stylesheet
├── sql/
│   └── community_portal_queries.sql   ← All 25 SQL Exercises + Schema + Data
├── jquery/
│   └── index2.html                     ← All 6 jQuery Exercises
└── csharp/
    └── Program.cs                     ← All 30 C# & ADO.NET Exercises
```

---

## ✅ Prerequisites — Install These First

| Tool | Download Link | Purpose |
|------|--------------|---------|
| Google Chrome | https://www.google.com/chrome | Run HTML, CSS, jQuery files |
| VS Code | https://code.visualstudio.com | Edit all files |
| .NET 8 SDK | https://dotnet.microsoft.com/download | Run C# exercises |
| MySQL 8.0+ | https://dev.mysql.com/downloads/mysql | Run SQL exercises |
| MySQL Workbench | https://dev.mysql.com/downloads/workbench | GUI for MySQL |

---

---

## 1️⃣ HTML5 Exercises

### 📄 File: `html5/index.html`

### Exercises Covered
| # | Exercise | What to Look For |
|---|----------|-----------------|
| 1 | Base Template | DOCTYPE, lang, charset, semantic tags, comments |
| 2 | Navigation & Linking | `<nav>`, anchor links, section IDs, external link |
| 3 | Welcome Banner | `#welcomeBanner`, inline style, `.highlight` class |
| 4 | Image Gallery | `<table>` 2×3, `<img>` with alt/title, class border |
| 5 | Registration Form | text, email, date, select, textarea, output element |
| 6 | Event Feedback | onblur, onchange, onclick, ondblclick, keypress |
| 7 | Video Invite | `<video>`, oncanplay, onbeforeunload warning |
| 8 | Preferences | localStorage save/restore, sessionStorage, clear button |
| 9 | Geolocation | getCurrentPosition, error handling, high accuracy |
| 10 | DevTools Debug | console.log statements visible in browser console |

### ▶️ How to Run

**Option A — Direct Open (simplest):**
1. Open File Explorer / Finder
2. Navigate to the `html5/` folder
3. Double-click `index.html`
4. It opens in your default browser

**Option B — VS Code Live Server (recommended):**
1. Open VS Code
2. Install the **Live Server** extension:
   - Click Extensions icon (left sidebar) → search `Live Server` → Install
3. Open the `html5/` folder in VS Code (`File → Open Folder`)
4. Right-click `index.html` in the Explorer panel
5. Click **"Open with Live Server"**
6. Browser opens at `http://127.0.0.1:5500/index.html`

### 🔍 How to Inspect with Chrome DevTools
1. Open the page in Chrome
2. Press `F12` to open DevTools
3. **Elements tab** → inspect HTML structure
4. **Console tab** → see the 3 log messages from Exercise 10
5. **Sources tab** → add breakpoints in the `<script>` section
6. **Device toolbar** (`Ctrl+Shift+M`) → simulate mobile screens

### 🧪 Testing Each Exercise
- **Ex 5 (Form):** Fill in all fields and click "Register Now" → green confirmation appears
- **Ex 6 (Feedback):** Type a phone number and click away → validation message appears
- **Ex 7 (Video):** Video player loads → "Video ready to play" appears below it
- **Ex 8 (Preferences):** Select an event type → refresh the page → it restores automatically
- **Ex 9 (Geolocation):** Click "Find Nearby Events" → allow location in browser popup

---

---

## 2️⃣ CSS3 Exercises

### 📄 Files: `css3/index.html` + `css3/styles.css`

### Exercises Covered
| # | Exercise | Where to See It |
|---|----------|----------------|
| 1 | Inline / Internal / External CSS | Red inline h3, `<style>` in head, linked styles.css |
| 2 | CSS Syntax & Comments | Open styles.css — every section has comments |
| 3 | Selectors | `*`, `h2`, `#mainHeader`, `.eventCard`, `h3,p` grouping |
| 4 | Color & Background | HEX, RGBA boxes, linear-gradient headers |
| 5 | Typography | Poppins Google Font, text-align, letter-spacing, line-height |
| 6 | Links & Lists | Hover/visited/active links, list-style-type, no-bullet nav |
| 7 | Table Styling | Zebra rows, border-collapse, centered text |
| 8 | Box Model | .eventCard border/padding/margin, outline on focus, visibility demo |
| 9 | Multi-Column Text | column-count:2, column-gap, column-rule |
| 10 | Responsive / Media Queries | Resize browser to see nav stack vertically at <768px |
| 11 | DevTools Debug | Inspect live styles, Network tab for styles.css |

### ▶️ How to Run

**Option A — Direct Open:**
1. Navigate to the `css3/` folder
2. Double-click `index.html`
3. ⚠️ The Google Font (Poppins) requires internet connection

**Option B — VS Code Live Server:**
1. Open VS Code → Open the `css3/` folder
2. Right-click `index.html` → **"Open with Live Server"**

> ⚠️ **Important:** Always open `index.html` from inside the `css3/` folder so the browser can find `styles.css` at the correct relative path.

### 🔍 Verifying the External CSS Loaded
1. Open Chrome DevTools (`F12`)
2. Go to **Network** tab
3. Refresh the page (`Ctrl+R`)
4. Look for `styles.css` in the list → status should be `200`

### 🧪 Testing Responsiveness
1. Open DevTools → click the **device toolbar icon** (📱) or press `Ctrl+Shift+M`
2. Select "iPhone SE" or set width to 375px
3. Observe: navigation stacks vertically, font sizes reduce, cards go full width
4. Select "iPad" (768px) to see the tablet breakpoint

---

---

## 3️⃣ SQL Exercises (MySQL)

### 📄 File: `sql/community_portal_queries.sql`

### Exercises Covered (25 queries)
| # | Query Topic |
|---|-------------|
| 1 | User Upcoming Events |
| 2 | Top Rated Events (avg rating ≥ threshold) |
| 3 | Inactive Users (no registration in 90 days) |
| 4 | Peak Session Hours (10AM–12PM) |
| 5 | Most Active Cities (Top 5) |
| 6 | Event Resource Summary (PDF/image/link count) |
| 7 | Low Feedback Alerts (rating < 3) |
| 8 | Sessions per Upcoming Event |
| 9 | Organizer Event Summary |
| 10 | Feedback Gap (registered but no feedback) |
| 11 | Daily New User Count (last 7 days) |
| 12 | Event with Maximum Sessions |
| 13 | Average Rating per City |
| 14 | Most Registered Events (Top 3) |
| 15 | Session Time Conflicts |
| 16 | Unregistered Active Users (joined in 30 days) |
| 17 | Multi-Session Speakers |
| 18 | Resource Availability Check |
| 19 | Completed Events with Feedback Summary |
| 20 | User Engagement Index |
| 21 | Top Feedback Providers (Top 5) |
| 22 | Duplicate Registrations Check |
| 23 | Registration Trends (12-month) |
| 24 | Average Session Duration per Event |
| 25 | Events Without Sessions |

### ▶️ How to Run — MySQL Workbench (GUI)

**Step 1: Start MySQL Server**
- Windows: Open **Services** → find `MySQL80` → Start
- Mac: System Preferences → MySQL → Start MySQL Server
- Or via terminal: `net start mysql` (Windows) / `sudo mysql.server start` (Mac)

**Step 2: Open MySQL Workbench**
1. Launch MySQL Workbench
2. Click your local connection (usually `root @ localhost:3306`)
3. Enter your password if prompted

**Step 3: Run the SQL file**

**Method A — Open and run the file:**
1. Click `File → Open SQL Script`
2. Navigate to `sql/community_portal_queries.sql`
3. Click Open
4. Press `Ctrl+Shift+Enter` to run the entire file
   - OR press `Ctrl+Enter` to run just the statement where your cursor is

**Method B — Copy and paste:**
1. Open the `.sql` file in any text editor
2. Copy all contents (`Ctrl+A` → `Ctrl+C`)
3. Paste into MySQL Workbench query editor
4. Click the ⚡ (lightning bolt) button or press `Ctrl+Shift+Enter`

### ▶️ How to Run — MySQL Command Line

```bash
# Step 1: Log into MySQL
mysql -u root -p
# Enter your password when prompted

# Step 2: Run the file directly
mysql -u root -p < path/to/sql/community_portal_queries.sql

# OR inside MySQL shell, run:
source /full/path/to/sql/community_portal_queries.sql;
```

### 🧪 Running Individual Exercises
After the schema and data are loaded (`USE community_portal;`), you can run each exercise query independently. Each is clearly labeled with a comment like:
```sql
-- EXERCISE 1: User Upcoming Events
```
Highlight just that query in Workbench and press `Ctrl+Enter`.

### ⚠️ Notes
- The file **creates the database**, tables, and inserts sample data automatically
- Run the full file once first to set everything up
- Exercise 2 (Top Rated Events) requires `feedback_count >= 10` — the sample data has fewer entries by design; the query logic is correct for real data

---

---

## 4️⃣ jQuery Exercises

### 📄 File: `jquery/index2.html`

### Exercises Covered
| # | Exercise | What to Test |
|---|----------|-------------|
| 1 | Library Inclusion | jQuery loaded via CDN; check Console for version log |
| 2 | $() Function | Change H3 text button; hide/show paragraph buttons |
| 3 | jQuery Methods | hide, show, fadeOut, fadeIn, toggle, slideUp→slideDown chain |
| 4 | DOM Manipulation | Type event name → Add to List; Remove All button |
| 5 | Working with Events | Click button → box turns red; double-click box → resets white |
| 6 | Event Helpers | click, dblclick, mouseenter, mouseleave on div; keypress on input |

### ▶️ How to Run

> ⚠️ jQuery is loaded from CDN — **you need an internet connection.**

**Option A — Direct Open:**
1. Navigate to the `jquery/` folder
2. Double-click `index.html`
3. Opens in browser — all exercises work immediately

**Option B — VS Code Live Server:**
1. Open VS Code → Open `jquery/` folder
2. Right-click `index.html` → **"Open with Live Server"**

### 🧪 Testing Each Exercise
- **Ex 1:** Open Console (`F12`) → see `jQuery version: 3.7.1` and `Hello World!`
- **Ex 2:** Click "Change H3 Text" → heading updates; click "Hide" → paragraph disappears
- **Ex 3:** Click each button to see the animation effect on the 3 blue boxes
- **Ex 4:** Type "Tech Meetup" in the input → click Add → appears in list; Enter key also works
- **Ex 5:** Click the button → color box turns red; double-click the box → resets to white
- **Ex 6:** Hover over the text div → border appears; click → background changes; type in the input → key info shows

---

---

## 5️⃣ C# & ADO.NET Exercises

### 📄 File: `csharp/Program.cs`

### Exercises Covered (30 programs)
| # | Exercise |
|---|----------|
| 1 | Hello World + Environment Setup |
| 2 | Value Types vs Reference Types |
| 3 | Primary Constructors (C# 12) |
| 4 | Type Inference with var and new() |
| 5 | Grade Calculation (if/else + switch pattern) |
| 6 | Loops (for, foreach, while, do-while) |
| 7 | Method Overloading |
| 8 | ref, out, in Parameters |
| 9 | Local Functions (factorial) |
| 10 | OOP Constructors (default + parameterized) |
| 11 | Access Modifiers (public, private, protected) |
| 12 | Auto-Properties & Backing Fields with validation |
| 13 | Records with init + with-expression |
| 14 | Inheritance & Method Overriding |
| 15 | Abstract Classes & Interfaces |
| 16 | Null References (?. and ??) |
| 17 | Null-Conditional Chaining in Contact App |
| 18 | required Modifier (C# 11) |
| 19 | List<T> and Dictionary<K,V> |
| 20 | LINQ Filtering & Projection |
| 21 | Pattern Matching (is + switch expression) |
| 22 | Tuples & Deconstruction |
| 23 | Async/Await File Upload Simulation |
| 24 | JSON Serialize & Deserialize |
| 25 | FileStream & MemoryStream |
| 26 | Race Conditions + lock statement |
| 27 | Deadlock Simulation + Monitor.TryEnter |
| 28 | Trace Logging (TextWriterTraceListener) |
| 29 | Input Sanitization / XSS Prevention |
| 30 | ADO.NET CRUD (requires SQL Server — see below) |

### ▶️ How to Run — Step by Step

**Step 1: Verify .NET is installed**
```bash
dotnet --version
# Should print: 8.0.xxx or higher
```
If not installed → download from https://dotnet.microsoft.com/download

**Step 2: Create a new Console project**
```bash
# Open Terminal / Command Prompt
# Navigate to where you want to create the project

dotnet new console -n CSharpExercises
cd CSharpExercises
```

**Step 3: Replace the default Program.cs**
```bash
# Windows (Command Prompt):
copy /Y "path\to\csharp\Program.cs" Program.cs

# Windows (PowerShell):
Copy-Item -Force "path\to\csharp\Program.cs" Program.cs

# Mac / Linux:
cp -f path/to/csharp/Program.cs Program.cs
```
Or simply open `Program.cs` in VS Code and paste in the contents.

**Step 4: Run the project**
```bash
dotnet run
```

All 29 exercises (Ex 1–29) will execute and print output to the terminal automatically.

### ▶️ How to Run in VS Code
1. Open VS Code
2. `File → Open Folder` → select the `CSharpExercises/` folder
3. Open `Program.cs`
4. Press `Ctrl+F5` (Run without debugging)
5. Output appears in the Terminal panel at the bottom

### ⚙️ Exercise 30: ADO.NET CRUD (SQL Server)

Exercise 30 requires **Microsoft SQL Server** and is commented out by default.

**To enable it:**

1. Install SQL Server (free Developer edition): https://www.microsoft.com/en-us/sql-server/sql-server-downloads
2. Install the NuGet package:
```bash
dotnet add package Microsoft.Data.SqlClient
```
3. Open `Program.cs` and:
   - Uncomment the `using Microsoft.Data.SqlClient;` line at the top
   - Uncomment the `Exercise30_CRUD_ADONet();` call in `Main()`
   - Uncomment the entire `Exercise30_CRUD_ADONet()` method at the bottom
4. Update the connection string if needed:
```csharp
string connStr = "Server=localhost;Database=community_portal;Trusted_Connection=True;TrustServerCertificate=True;";
```
5. Run: `dotnet run`

### 🔍 Running Individual Exercises in VS Code
To run just one exercise at a time, comment out the other calls in `Main()`:
```csharp
static async Task Main(string[] args)
{
    // Comment out everything else, keep only what you want:
    Exercise05_GradeCalculation();
}
```
Then press `Ctrl+F5`.

---

---

## 🛠️ VS Code — Recommended Extensions

Install these for the best experience:

| Extension | Purpose |
|-----------|---------|
| **Live Server** (Ritwick Dey) | Run HTML files with auto-reload |
| **C# Dev Kit** (Microsoft) | IntelliSense, debugging for C# |
| **MySQL** (cweijan) | Run SQL queries from VS Code |
| **Prettier** | Auto-format HTML/CSS/JS |
| **IntelliSense for CSS** | CSS autocomplete |

To install: Click Extensions icon in VS Code sidebar → Search → Install

---

## ⚡ Quick Reference — Run Commands

```bash
# HTML5 / CSS3 / jQuery
# Just double-click the index.html file, or use VS Code Live Server

# SQL (MySQL)
mysql -u root -p < sql/community_portal_queries.sql

# C# (Exercises 1–29)
dotnet new console -n CSharpExercises
cd CSharpExercises
# Copy Program.cs into this folder
dotnet run

# C# Exercise 30 (ADO.NET — extra step)
dotnet add package Microsoft.Data.SqlClient
# Uncomment Ex30 code in Program.cs
dotnet run
```

---

## 📌 Submission Checklist

- [ ] `html5/index.html` — opens in Chrome, all 10 exercises visible
- [ ] `css3/index.html` + `css3/styles.css` — all 11 CSS sections working
- [ ] `sql/community_portal_queries.sql` — all 25 queries run without errors in MySQL
- [ ] `jquery/index.html` — all 6 jQuery exercises interactive in browser
- [ ] `csharp/Program.cs` — all 29 exercises print output via `dotnet run`
- [ ] Exercise 30 enabled separately with SQL Server if required

---

*Local Community Event Portal — Cognizant Upskilling Submission*
