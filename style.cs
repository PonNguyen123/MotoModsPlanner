/* ================ 
   Base + Reset
=================== */

*,
*::before,
*::after {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

:root {
  --bg: #05060a;
  --bg-alt: #0b0d14;
  --card: #11141f;
  --accent: #ff4444;
  --accent-soft: rgba(255, 68, 68, 0.15);
  --text: #f5f5f5;
  --muted: #a0a4b8;
  --border: #222636;
  --radius-lg: 18px;
  --radius-md: 10px;
  --shadow-soft: 0 18px 40px rgba(0, 0, 0, 0.55);
  --shadow-subtle: 0 10px 25px rgba(0, 0, 0, 0.35);
}

html,
body {
  height: 100%;
}

body {
  font-family: system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif;
  background: radial-gradient(circle at top, #15192b 0, #05060a 55%);
  color: var(--text);
  line-height: 1.5;
}

/* ================ 
   Layout
=================== */

main {
  max-width: 1100px;
  margin: 0 auto;
  padding: 96px 20px 72px;
}

/* ================ 
   Header / Nav
=================== */

.site-header {
  position: sticky;
  top: 0;
  z-index: 20;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 14px 22px;
  background: linear-gradient(to bottom, rgba(5, 6, 10, 0.95), rgba(5, 6, 10, 0.6));
  backdrop-filter: blur(14px);
  border-bottom: 1px solid rgba(255, 255, 255, 0.035);
}

.logo {
  font-weight: 700;
  letter-spacing: 0.08em;
  text-transform: uppercase;
  font-size: 0.9rem;
}

.logo span {
  color: var(--accent);
}

.nav {
  display: flex;
  gap: 18px;
}

.nav a {
  font-size: 0.85rem;
  text-decoration: none;
  color: var(--muted);
  padding: 6px 10px;
  border-radius: 999px;
  transition: color 0.2s ease, background-color 0.2s ease, transform 0.15s ease;
}

.nav a:hover {
  color: var(--text);
  background: rgba(255, 255, 255, 0.06);
  transform: translateY(-1px);
}

/* ================ 
   Hero
=================== */

.hero {
  min-height: 60vh;
  display: flex;
  align-items: center;
}

.hero-content {
  max-width: 600px;
  padding: 32px 22px;
  border-radius: var(--radius-lg);
  background: radial-gradient(circle at top left, rgba(255, 255, 255, 0.05) 0, #05060a 50%);
  box-shadow: var(--shadow-soft);
  border: 1px solid rgba(255, 255, 255, 0.06);
  position: relative;
  overflow: hidden;
}

.hero-content::before {
  content: "";
  position: absolute;
  inset: -40%;
  background: radial-gradient(circle at 10% 0, rgba(255, 68, 68, 0.18), transparent 55%);
  opacity: 0.8;
  pointer-events: none;
}

.hero-content h1 {
  position: relative;
  font-size: clamp(2.2rem, 4vw, 2.9rem);
  margin-bottom: 10px;
}

.hero-content p {
  position: relative;
  color: var(--muted);
  max-width: 460px;
  margin-bottom: 20px;
  font-size: 0.95rem;
}

.primary-btn,
.secondary-btn {
  position: relative;
  border-radius: 999px;
  padding: 10px 20px;
  font-size: 0.9rem;
  border: none;
  cursor: pointer;
  font-weight: 500;
  letter-spacing: 0.03em;
  text-transform: uppercase;
  transition: transform 0.14s ease, box-shadow 0.14s ease, background 0.18s ease;
}

.primary-btn {
  background: linear-gradient(135deg, var(--accent), #ff7b54);
  color: #fff;
  box-shadow: var(--shadow-subtle);
}

.primary-btn:hover {
  transform: translateY(-1px);
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.55);
}

.secondary-btn {
  background: rgba(255, 255, 255, 0.06);
  color: var(--text);
  border: 1px solid rgba(255, 255, 255, 0.07);
}

.secondary-btn:hover {
  transform: translateY(-1px);
}

/* ================ 
   Sections generic
=================== */

section {
  margin-bottom: 72px;
}

section h2 {
  font-size: 1.5rem;
  margin-bottom: 12px;
}

section p {
  color: var(--muted);
  font-size: 0.95rem;
}

/* ================ 
   Features
=================== */

.features {
  padding: 0 4px;
}

.feature-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
  gap: 16px;
  margin-top: 18px;
}

.feature-card {
  background: var(--card);
  border-radius: var(--radius-md);
  padding: 18px 16px;
  border: 1px solid var(--border);
  box-shadow: var(--shadow-subtle);
  position: relative;
  overflow: hidden;
}

.feature-card::before {
  content: "";
  position: absolute;
  inset: 0;
  background: linear-gradient(135deg, rgba(255, 68, 68, 0.2), transparent 50%);
  opacity: 0;
  transition: opacity 0.2s ease;
}

.feature-card h3 {
  margin-bottom: 8px;
  font-size: 1rem;
}

.feature-card p {
  font-size: 0.9rem;
}

.feature-card:hover::before {
  opacity: 1;
}

/* ================ 
   Planner
=================== */

.planner {
  background: var(--bg-alt);
  border-radius: var(--radius-lg);
  padding: 22px 16px 18px;
  box-shadow: var(--shadow-soft);
  border: 1px solid rgba(255, 255, 255, 0.06);
}

.planner-intro {
  margin-bottom: 14px;
}

/* Budget panel */

.budget-panel {
  display: grid;
  grid-template-columns: minmax(0, 1.1fr) minmax(0, 2fr);
  gap: 14px;
  margin-bottom: 18px;
  padding: 10px 12px;
  border-radius: var(--radius-md);
  border: 1px solid var(--border);
  background: #05060f;
}

.budget-row {
  display: flex;
  flex-direction: column;
  gap: 6px;
}

.budget-row label {
  font-size: 0.8rem;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  color: var(--muted);
}

.budget-progress-text {
  display: flex;
  justify-content: space-between;
  font-size: 0.8rem;
  color: var(--muted);
}

.budget-bar {
  position: relative;
  width: 100%;
  height: 8px;
  border-radius: 999px;
  background: rgba(255, 255, 255, 0.06);
  overflow: hidden;
}

.budget-bar-fill {
  position: absolute;
  inset: 0;
  width: 0%;
  background: linear-gradient(90deg, var(--accent), #ffb054);
  transition: width 0.2s ease;
}

.budget-over {
  color: #ffbdbd !important;
}

.budget-bar-over {
  background: linear-gradient(90deg, #ff4444, #ff7b54);
}

/* Planner form and output */

.mod-form {
  display: grid;
  grid-template-columns: repeat(3, minmax(0, 1fr));
  gap: 14px;
  margin-bottom: 20px;
}

.form-row {
  display: flex;
  flex-direction: column;
  gap: 6px;
}

.form-row label {
  font-size: 0.8rem;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  color: var(--muted);
}

input[type="text"],
input[type="number"],
select {
  background: #05060a;
  border-radius: 999px;
  border: 1px solid var(--border);
  padding: 8px 11px;
  color: var(--text);
  font-size: 0.9rem;
  outline: none;
  transition: border-color 0.18s ease, box-shadow 0.18s ease, background 0.18s ease;
}

input[type="text"]:focus,
input[type="number"]:focus,
select:focus {
  border-color: var(--accent);
  box-shadow: 0 0 0 1px rgba(255, 68, 68, 0.4);
  background: #080a12;
}

.mod-form .primary-btn {
  align-self: flex-end;
  width: 100%;
}

.planner-output {
  display: grid;
  grid-template-columns: minmax(0, 2fr) minmax(0, 1.2fr);
  gap: 18px;
}

.mod-list {
  list-style: none;
  border-radius: var(--radius-md);
  border: 1px solid var(--border);
  background: #080a13;
  max-height: 220px;
  overflow-y: auto;
}

.mod-item {
  display: grid;
  grid-template-columns: 2.3fr 1.3fr 1fr auto;
  padding: 10px 12px;
  border-bottom: 1px solid rgba(255, 255, 255, 0.03);
  gap: 8px;
  font-size: 0.85rem;
  align-items: center;
}

.mod-item:last-child {
  border-bottom: none;
}

.mod-item span {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.mod-category {
  color: var(--accent);
  font-size: 0.8rem;
  text-transform: uppercase;
  letter-spacing: 0.05em;
}

.mod-cost {
  text-align: right;
}

.remove-btn {
  background: transparent;
  border: none;
  color: var(--muted);
  cursor: pointer;
  font-size: 0.8rem;
  padding: 4px;
  border-radius: 999px;
  transition: background 0.15s ease, color 0.15s ease;
}

.remove-btn:hover {
  background: rgba(255, 255, 255, 0.07);
  color: #fff;
}

.planner-summary {
  border-radius: var(--radius-md);
  border: 1px solid var(--border);
  padding: 14px 12px;
  background: radial-gradient(circle at top right, var(--accent-soft), #05060a);
  display: flex;
  flex-direction: column;
  gap: 10px;
  font-size: 0.9rem;
}

#totalCost {
  font-weight: 600;
}

.idea-output {
  min-height: 38px;
  font-size: 0.9rem;
  color: var(--muted);
}

/* Category summary */

.category-summary {
  margin-top: 10px;
  border-top: 1px dashed rgba(255, 255, 255, 0.12);
  padding-top: 10px;
}

.category-summary h4 {
  font-size: 0.8rem;
  text-transform: uppercase;
  letter-spacing: 0.06em;
  color: var(--muted);
  margin-bottom: 6px;
}

.category-summary-list {
  display: flex;
  flex-wrap: wrap;
  gap: 6px;
}

.category-pill {
  font-size: 0.78rem;
  padding: 4px 9px;
  border-radius: 999px;
  background: rgba(255, 255, 255, 0.05);
  border: 1px solid rgba(255, 255, 255, 0.06);
  color: var(--muted);
}

/* ================ 
   About
=================== */

.about {
  padding: 10px 4px 0;
}

/* ================ 
   Footer
=================== */

.site-footer {
  border-top: 1px solid rgba(255, 255, 255, 0.04);
  padding: 16px 22px 22px;
  text-align: center;
  font-size: 0.8rem;
  color: var(--muted);
}

/* ================ 
   Responsive
=================== */

@media (max-width: 768px) {
  main {
    padding-top: 80px;
  }

  .site-header {
    padding-inline: 16px;
  }

  .nav {
    gap: 10px;
  }

  .nav a {
    font-size: 0.75rem;
    padding-inline: 8px;
  }

  .hero-content {
    padding: 22px 18px;
  }

  .budget-panel {
    grid-template-columns: 1fr;
  }

  .mod-form {
    grid-template-columns: 1fr;
  }

  .planner-output {
    grid-template-columns: 1fr;
  }

  .mod-item {
    grid-template-columns: 2fr 1fr;
    grid-template-rows: auto auto;
  }

  .mod-category {
    grid-column: 1 / -1;
  }
}
