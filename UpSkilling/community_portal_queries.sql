-- ============================================================
-- ANSI SQL Using MySQL — Community Event Portal
-- All 25 Exercises with Schema + Sample Data + Queries
-- ============================================================

-- ============================================================
-- DATABASE SETUP
-- ============================================================
CREATE DATABASE IF NOT EXISTS community_portal;
USE community_portal;

-- ============================================================
-- TABLE CREATION
-- ============================================================

-- 1. Users
CREATE TABLE IF NOT EXISTS Users (
    user_id           INT PRIMARY KEY AUTO_INCREMENT,
    full_name         VARCHAR(100) NOT NULL,
    email             VARCHAR(100) UNIQUE NOT NULL,
    city              VARCHAR(100) NOT NULL,
    registration_date DATE NOT NULL
);

-- 2. Events
CREATE TABLE IF NOT EXISTS Events (
    event_id     INT PRIMARY KEY AUTO_INCREMENT,
    title        VARCHAR(200) NOT NULL,
    description  TEXT,
    city         VARCHAR(100) NOT NULL,
    start_date   DATETIME NOT NULL,
    end_date     DATETIME NOT NULL,
    status       ENUM('upcoming','completed','cancelled') NOT NULL DEFAULT 'upcoming',
    organizer_id INT,
    FOREIGN KEY (organizer_id) REFERENCES Users(user_id)
);

-- 3. Sessions
CREATE TABLE IF NOT EXISTS Sessions (
    session_id   INT PRIMARY KEY AUTO_INCREMENT,
    event_id     INT NOT NULL,
    title        VARCHAR(200) NOT NULL,
    speaker_name VARCHAR(100) NOT NULL,
    start_time   DATETIME NOT NULL,
    end_time     DATETIME NOT NULL,
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);

-- 4. Registrations
CREATE TABLE IF NOT EXISTS Registrations (
    registration_id   INT PRIMARY KEY AUTO_INCREMENT,
    user_id           INT NOT NULL,
    event_id          INT NOT NULL,
    registration_date DATE NOT NULL,
    FOREIGN KEY (user_id)  REFERENCES Users(user_id),
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);

-- 5. Feedback
CREATE TABLE IF NOT EXISTS Feedback (
    feedback_id   INT PRIMARY KEY AUTO_INCREMENT,
    user_id       INT NOT NULL,
    event_id      INT NOT NULL,
    rating        INT CHECK (rating BETWEEN 1 AND 5),
    comments      TEXT,
    feedback_date DATE NOT NULL,
    FOREIGN KEY (user_id)  REFERENCES Users(user_id),
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);

-- 6. Resources
CREATE TABLE IF NOT EXISTS Resources (
    resource_id   INT PRIMARY KEY AUTO_INCREMENT,
    event_id      INT NOT NULL,
    resource_type ENUM('pdf','image','link') NOT NULL,
    resource_url  VARCHAR(255) NOT NULL,
    uploaded_at   DATETIME NOT NULL,
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);

-- ============================================================
-- SAMPLE DATA
-- ============================================================

INSERT INTO Users (full_name, email, city, registration_date) VALUES
('Alice Johnson', 'alice@example.com', 'New York',    '2024-12-01'),
('Bob Smith',     'bob@example.com',   'Los Angeles', '2024-12-05'),
('Charlie Lee',   'charlie@example.com','Chicago',    '2024-12-10'),
('Diana King',    'diana@example.com', 'New York',    '2025-01-15'),
('Ethan Hunt',    'ethan@example.com', 'Los Angeles', '2025-02-01');

INSERT INTO Events (title, description, city, start_date, end_date, status, organizer_id) VALUES
('Tech Innovators Meetup',      'A meetup for tech enthusiasts.',          'New York',    '2025-06-10 10:00:00','2025-06-10 16:00:00','upcoming',  1),
('AI & ML Conference',          'Conference on AI and ML advancements.',   'Chicago',     '2025-05-15 09:00:00','2025-05-15 17:00:00','completed', 3),
('Frontend Development Bootcamp','Hands-on training on frontend tech.',    'Los Angeles', '2025-07-01 10:00:00','2025-07-03 16:00:00','upcoming',  2);

INSERT INTO Sessions (event_id, title, speaker_name, start_time, end_time) VALUES
(1, 'Opening Keynote',    'Dr. Tech',      '2025-06-10 10:00:00','2025-06-10 11:00:00'),
(1, 'Future of Web Dev',  'Alice Johnson', '2025-06-10 11:15:00','2025-06-10 12:30:00'),
(2, 'AI in Healthcare',   'Charlie Lee',   '2025-05-15 09:30:00','2025-05-15 11:00:00'),
(3, 'Intro to HTML5',     'Bob Smith',     '2025-07-01 10:00:00','2025-07-01 12:00:00');

INSERT INTO Registrations (user_id, event_id, registration_date) VALUES
(1, 1, '2025-05-01'),
(2, 1, '2025-05-02'),
(3, 2, '2025-04-30'),
(4, 2, '2025-04-28'),
(5, 3, '2025-06-15');

INSERT INTO Feedback (user_id, event_id, rating, comments, feedback_date) VALUES
(3, 2, 4, 'Great insights!',       '2025-05-16'),
(4, 2, 5, 'Very informative.',     '2025-05-16'),
(2, 1, 3, 'Could be better.',      '2025-06-11');

INSERT INTO Resources (event_id, resource_type, resource_url, uploaded_at) VALUES
(1, 'pdf',   'https://portal.com/resources/tech_meetup_agenda.pdf', '2025-05-01 10:00:00'),
(2, 'image', 'https://portal.com/resources/ai_poster.jpg',          '2025-04-20 09:00:00'),
(3, 'link',  'https://portal.com/resources/html5_docs',             '2025-06-25 15:00:00');


-- ============================================================
-- EXERCISE 1: User Upcoming Events
-- Show all upcoming events a user is registered for in their city, sorted by date.
-- ============================================================
SELECT
    u.full_name,
    e.title         AS event_title,
    e.city,
    e.start_date,
    e.status
FROM Users u
JOIN Registrations r ON u.user_id = r.user_id
JOIN Events e        ON r.event_id = e.event_id
WHERE e.status = 'upcoming'
  AND e.city   = u.city
ORDER BY e.start_date ASC;


-- ============================================================
-- EXERCISE 2: Top Rated Events
-- Events with highest avg rating where feedback count >= 10.
-- (Sample data has < 10 entries; query is correct for real data)
-- ============================================================
SELECT
    e.title,
    ROUND(AVG(f.rating), 2) AS avg_rating,
    COUNT(f.feedback_id)    AS feedback_count
FROM Events e
JOIN Feedback f ON e.event_id = f.event_id
GROUP BY e.event_id, e.title
HAVING COUNT(f.feedback_id) >= 10
ORDER BY avg_rating DESC;


-- ============================================================
-- EXERCISE 3: Inactive Users
-- Users with no registrations in the last 90 days.
-- ============================================================
SELECT
    u.user_id,
    u.full_name,
    u.email,
    u.city,
    MAX(r.registration_date) AS last_registration
FROM Users u
LEFT JOIN Registrations r ON u.user_id = r.user_id
GROUP BY u.user_id, u.full_name, u.email, u.city
HAVING last_registration IS NULL
    OR last_registration < DATE_SUB(CURDATE(), INTERVAL 90 DAY);


-- ============================================================
-- EXERCISE 4: Peak Session Hours
-- Sessions scheduled between 10 AM and 12 PM per event.
-- ============================================================
SELECT
    e.title         AS event_title,
    COUNT(s.session_id) AS sessions_in_peak_hours
FROM Events e
JOIN Sessions s ON e.event_id = s.event_id
WHERE HOUR(s.start_time) >= 10
  AND HOUR(s.start_time) <  12
GROUP BY e.event_id, e.title
ORDER BY sessions_in_peak_hours DESC;


-- ============================================================
-- EXERCISE 5: Most Active Cities
-- Top 5 cities by distinct user registrations.
-- ============================================================
SELECT
    u.city,
    COUNT(DISTINCT r.user_id) AS distinct_registrations
FROM Users u
JOIN Registrations r ON u.user_id = r.user_id
GROUP BY u.city
ORDER BY distinct_registrations DESC
LIMIT 5;


-- ============================================================
-- EXERCISE 6: Event Resource Summary
-- Number of PDFs, images, and links uploaded per event.
-- ============================================================
SELECT
    e.title AS event_title,
    SUM(CASE WHEN r.resource_type = 'pdf'   THEN 1 ELSE 0 END) AS pdf_count,
    SUM(CASE WHEN r.resource_type = 'image' THEN 1 ELSE 0 END) AS image_count,
    SUM(CASE WHEN r.resource_type = 'link'  THEN 1 ELSE 0 END) AS link_count,
    COUNT(r.resource_id) AS total_resources
FROM Events e
LEFT JOIN Resources r ON e.event_id = r.event_id
GROUP BY e.event_id, e.title
ORDER BY total_resources DESC;


-- ============================================================
-- EXERCISE 7: Low Feedback Alerts
-- Users who gave rating < 3, with comments and event name.
-- ============================================================
SELECT
    u.full_name,
    u.email,
    e.title   AS event_title,
    f.rating,
    f.comments,
    f.feedback_date
FROM Feedback f
JOIN Users  u ON f.user_id  = u.user_id
JOIN Events e ON f.event_id = e.event_id
WHERE f.rating < 3
ORDER BY f.rating ASC;


-- ============================================================
-- EXERCISE 8: Sessions per Upcoming Event
-- Upcoming events with their session count.
-- ============================================================
SELECT
    e.title     AS event_title,
    e.city,
    e.start_date,
    COUNT(s.session_id) AS session_count
FROM Events e
LEFT JOIN Sessions s ON e.event_id = s.event_id
WHERE e.status = 'upcoming'
GROUP BY e.event_id, e.title, e.city, e.start_date
ORDER BY e.start_date ASC;


-- ============================================================
-- EXERCISE 9: Organizer Event Summary
-- Events created per organizer with status breakdown.
-- ============================================================
SELECT
    u.full_name AS organizer_name,
    COUNT(e.event_id) AS total_events,
    SUM(CASE WHEN e.status = 'upcoming'  THEN 1 ELSE 0 END) AS upcoming,
    SUM(CASE WHEN e.status = 'completed' THEN 1 ELSE 0 END) AS completed,
    SUM(CASE WHEN e.status = 'cancelled' THEN 1 ELSE 0 END) AS cancelled
FROM Users u
JOIN Events e ON u.user_id = e.organizer_id
GROUP BY u.user_id, u.full_name
ORDER BY total_events DESC;


-- ============================================================
-- EXERCISE 10: Feedback Gap
-- Events with registrations but zero feedback.
-- ============================================================
SELECT
    e.event_id,
    e.title,
    e.city,
    e.status,
    COUNT(DISTINCT r.registration_id) AS total_registrations
FROM Events e
JOIN Registrations r ON e.event_id = r.event_id
LEFT JOIN Feedback  f ON e.event_id = f.event_id
WHERE f.feedback_id IS NULL
GROUP BY e.event_id, e.title, e.city, e.status;


-- ============================================================
-- EXERCISE 11: Daily New User Count
-- New user registrations per day in the last 7 days.
-- ============================================================
SELECT
    registration_date,
    COUNT(user_id) AS new_users
FROM Users
WHERE registration_date >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
GROUP BY registration_date
ORDER BY registration_date DESC;


-- ============================================================
-- EXERCISE 12: Event with Maximum Sessions
-- Event(s) with the highest number of sessions.
-- ============================================================
SELECT
    e.title,
    COUNT(s.session_id) AS session_count
FROM Events e
JOIN Sessions s ON e.event_id = s.event_id
GROUP BY e.event_id, e.title
HAVING COUNT(s.session_id) = (
    SELECT MAX(cnt) FROM (
        SELECT COUNT(session_id) AS cnt
        FROM Sessions
        GROUP BY event_id
    ) AS sub
);


-- ============================================================
-- EXERCISE 13: Average Rating per City
-- Average feedback rating for events in each city.
-- ============================================================
SELECT
    e.city,
    ROUND(AVG(f.rating), 2) AS avg_rating,
    COUNT(f.feedback_id)    AS total_feedback
FROM Events e
JOIN Feedback f ON e.event_id = f.event_id
GROUP BY e.city
ORDER BY avg_rating DESC;


-- ============================================================
-- EXERCISE 14: Most Registered Events
-- Top 3 events by total user registrations.
-- ============================================================
SELECT
    e.title,
    e.city,
    COUNT(r.registration_id) AS total_registrations
FROM Events e
JOIN Registrations r ON e.event_id = r.event_id
GROUP BY e.event_id, e.title, e.city
ORDER BY total_registrations DESC
LIMIT 3;


-- ============================================================
-- EXERCISE 15: Event Session Time Conflict
-- Overlapping sessions within the same event.
-- ============================================================
SELECT
    s1.event_id,
    e.title       AS event_title,
    s1.session_id AS session1_id,
    s1.title      AS session1_title,
    s1.start_time AS s1_start,
    s1.end_time   AS s1_end,
    s2.session_id AS session2_id,
    s2.title      AS session2_title,
    s2.start_time AS s2_start,
    s2.end_time   AS s2_end
FROM Sessions s1
JOIN Sessions s2  ON s1.event_id = s2.event_id
                 AND s1.session_id < s2.session_id
JOIN Events   e   ON s1.event_id  = e.event_id
WHERE s1.start_time < s2.end_time
  AND s1.end_time   > s2.start_time;


-- ============================================================
-- EXERCISE 16: Unregistered Active Users
-- Users who joined in the last 30 days but haven't registered for any event.
-- ============================================================
SELECT
    u.user_id,
    u.full_name,
    u.email,
    u.city,
    u.registration_date
FROM Users u
LEFT JOIN Registrations r ON u.user_id = r.user_id
WHERE u.registration_date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
  AND r.registration_id IS NULL;


-- ============================================================
-- EXERCISE 17: Multi-Session Speakers
-- Speakers handling more than one session across all events.
-- ============================================================
SELECT
    speaker_name,
    COUNT(session_id) AS session_count,
    GROUP_CONCAT(title ORDER BY start_time SEPARATOR ' | ') AS sessions
FROM Sessions
GROUP BY speaker_name
HAVING COUNT(session_id) > 1
ORDER BY session_count DESC;


-- ============================================================
-- EXERCISE 18: Resource Availability Check
-- Events with no resources uploaded.
-- ============================================================
SELECT
    e.event_id,
    e.title,
    e.city,
    e.status
FROM Events e
LEFT JOIN Resources r ON e.event_id = r.event_id
WHERE r.resource_id IS NULL;


-- ============================================================
-- EXERCISE 19: Completed Events with Feedback Summary
-- Total registrations and average rating for completed events.
-- ============================================================
SELECT
    e.title,
    e.city,
    e.end_date,
    COUNT(DISTINCT r.registration_id) AS total_registrations,
    ROUND(AVG(f.rating), 2)           AS avg_feedback_rating,
    COUNT(DISTINCT f.feedback_id)     AS total_feedback_entries
FROM Events e
LEFT JOIN Registrations r ON e.event_id = r.event_id
LEFT JOIN Feedback      f ON e.event_id = f.event_id
WHERE e.status = 'completed'
GROUP BY e.event_id, e.title, e.city, e.end_date;


-- ============================================================
-- EXERCISE 20: User Engagement Index
-- Events attended + feedback submitted per user.
-- ============================================================
SELECT
    u.full_name,
    u.city,
    COUNT(DISTINCT r.event_id)   AS events_attended,
    COUNT(DISTINCT f.feedback_id) AS feedbacks_submitted
FROM Users u
LEFT JOIN Registrations r ON u.user_id = r.user_id
LEFT JOIN Feedback      f ON u.user_id = f.user_id
GROUP BY u.user_id, u.full_name, u.city
ORDER BY events_attended DESC, feedbacks_submitted DESC;


-- ============================================================
-- EXERCISE 21: Top Feedback Providers
-- Top 5 users with the most feedback submissions.
-- ============================================================
SELECT
    u.full_name,
    u.email,
    COUNT(f.feedback_id) AS feedback_count
FROM Users u
JOIN Feedback f ON u.user_id = f.user_id
GROUP BY u.user_id, u.full_name, u.email
ORDER BY feedback_count DESC
LIMIT 5;


-- ============================================================
-- EXERCISE 22: Duplicate Registrations Check
-- Users registered more than once for the same event.
-- ============================================================
SELECT
    user_id,
    event_id,
    COUNT(*) AS registration_count
FROM Registrations
GROUP BY user_id, event_id
HAVING COUNT(*) > 1;


-- ============================================================
-- EXERCISE 23: Registration Trends
-- Month-wise registration count over the past 12 months.
-- ============================================================
SELECT
    DATE_FORMAT(registration_date, '%Y-%m') AS month,
    COUNT(registration_id)                  AS registrations
FROM Registrations
WHERE registration_date >= DATE_SUB(CURDATE(), INTERVAL 12 MONTH)
GROUP BY DATE_FORMAT(registration_date, '%Y-%m')
ORDER BY month ASC;


-- ============================================================
-- EXERCISE 24: Average Session Duration per Event
-- Average session length in minutes for each event.
-- ============================================================
SELECT
    e.title AS event_title,
    ROUND(
        AVG(TIMESTAMPDIFF(MINUTE, s.start_time, s.end_time)),
    2) AS avg_duration_minutes
FROM Events e
JOIN Sessions s ON e.event_id = s.event_id
GROUP BY e.event_id, e.title
ORDER BY avg_duration_minutes DESC;


-- ============================================================
-- EXERCISE 25: Events Without Sessions
-- Events that have no sessions scheduled.
-- ============================================================
SELECT
    e.event_id,
    e.title,
    e.city,
    e.status,
    e.start_date
FROM Events e
LEFT JOIN Sessions s ON e.event_id = s.event_id
WHERE s.session_id IS NULL
ORDER BY e.start_date ASC;
