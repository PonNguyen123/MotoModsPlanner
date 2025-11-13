// ================
// Smooth scroll from hero button to planner
// ================

const startPlannerBtn = document.getElementById("startPlannerBtn");
const plannerSection = document.getElementById("planner");

if (startPlannerBtn && plannerSection) {
  startPlannerBtn.addEventListener("click", () => {
    plannerSection.scrollIntoView({ behavior: "smooth" });
  });
}

// ================
// DOM References
// ================

const modForm = document.getElementById("modForm");
const modNameInput = document.getElementById("modName");
const modCategorySelect = document.getElementById("modCategory");
const modCostInput = document.getElementById("modCost");
const modList = document.getElementById("modList");
const totalCostEl = document.getElementById("totalCost");

const budgetInput = document.getElementById("budgetInput");
const budgetBarFill = document.getElementById("budgetBarFill");
const budgetPercentEl = document.getElementById("budgetPercent");
const categorySummaryList = document.getElementById("categorySummaryList");

const randomIdeaBtn = document.getElementById("randomIdeaBtn");
const ideaOutput = document.getElementById("ideaOutput");

// ================
// State
// ================

let mods = []; // {id, name, category, cost}
let totalCost = 0;
let categoriesCount = {};
const STORAGE_KEY = "motomods-planner-data";

// ================
// Helpers
// ================

function formatCurrency(value) {
  return "$" + Number(value).toLocaleString();
}

function updateTotalCostDisplay() {
  totalCostEl.textContent = formatCurrency(totalCost);
}

function recomputeState() {
  totalCost = 0;
  categoriesCount = {};

  mods.forEach((mod) => {
    totalCost += mod.cost;
    categoriesCount[mod.category] = (categoriesCount[mod.category] || 0) + 1;
  });

  updateTotalCostDisplay();
  renderCategorySummary();
  updateBudgetProgress();
}

function renderCategorySummary() {
  if (!categorySummaryList) return;

  categorySummaryList.innerHTML = "";

  const entries = Object.entries(categoriesCount);

  if (entries.length === 0) {
    const span = document.createElement("span");
    span.className = "category-pill";
    span.textContent = "No mods yet";
    categorySummaryList.appendChild(span);
    return;
  }

  entries.forEach(([category, count]) => {
    const pill = document.createElement("span");
    pill.className = "category-pill";
    pill.textContent = `${category}: ${count}`;
    categorySummaryList.appendChild(pill);
  });
}

function updateBudgetProgress() {
  if (!budgetInput || !budgetBarFill || !budgetPercentEl) return;

  const rawBudget = budgetInput.value.trim();
  const budget = Number(rawBudget);

  budgetBarFill.classList.remove("budget-bar-over");
  budgetPercentEl.classList.remove("budget-over");

  if (!rawBudget || isNaN(budget) || budget <= 0) {
    budgetBarFill.style.width = "0%";
    budgetPercentEl.textContent = "—";
    return;
  }

  let percent = (totalCost / budget) * 100;
  if (percent > 999) percent = 999;
  const displayPercent = Math.round(percent);

  const clampedForBar = Math.min(percent, 100);
  budgetBarFill.style.width = clampedForBar + "%";
  budgetPercentEl.textContent = displayPercent + "%";

  if (percent > 100) {
    budgetBarFill.classList.add("budget-bar-over");
    budgetPercentEl.classList.add("budget-over");
  }
}

function createModItemElement(mod) {
  const li = document.createElement("li");
  li.className = "mod-item";
  li.dataset.id = mod.id;

  const nameSpan = document.createElement("span");
  nameSpan.textContent = mod.name;

  const categorySpan = document.createElement("span");
  categorySpan.className = "mod-category";
  categorySpan.textContent = mod.category;

  const costSpan = document.createElement("span");
  costSpan.className = "mod-cost";
  costSpan.textContent = formatCurrency(mod.cost);

  const removeBtn = document.createElement("button");
  removeBtn.className = "remove-btn";
  removeBtn.type = "button";
  removeBtn.textContent = "Remove";

  removeBtn.addEventListener("click", () => {
    const id = li.dataset.id;
    mods = mods.filter((m) => String(m.id) !== String(id));
    renderModList();
    recomputeState();
    saveData();
  });

  li.appendChild(nameSpan);
  li.appendChild(categorySpan);
  li.appendChild(costSpan);
  li.appendChild(removeBtn);

  return li;
}

function renderModList() {
  if (!modList) return;
  modList.innerHTML = "";
  mods.forEach((mod) => {
    const li = createModItemElement(mod);
    modList.appendChild(li);
  });
}

function saveData() {
  const payload = {
    mods,
    budget: budgetInput ? budgetInput.value : "",
  };
  try {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(payload));
  } catch (e) {
    // ignore storage errors
  }
}

function loadData() {
  try {
    const raw = localStorage.getItem(STORAGE_KEY);
    if (!raw) {
      recomputeState();
      renderModList();
      return;
    }

    const parsed = JSON.parse(raw);
    mods = Array.isArray(parsed.mods) ? parsed.mods : [];
    if (budgetInput && typeof parsed.budget === "string") {
      budgetInput.value = parsed.budget;
    }

    renderModList();
    recomputeState();
  } catch (e) {
    mods = [];
    recomputeState();
    renderModList();
  }
}

// ================
// Form handling
// ================

if (modForm) {
  modForm.addEventListener("submit", (event) => {
    event.preventDefault();

    const name = modNameInput.value.trim();
    const category = modCategorySelect.value;
    const costValue = modCostInput.value.trim();
    const cost = Number(costValue);

    if (!name || isNaN(cost) || cost < 0) {
      alert("Please enter a valid mod name and cost.");
      return;
    }

    const newMod = {
      id: Date.now() + Math.random(),
      name,
      category,
      cost,
    };

    mods.push(newMod);
    renderModList();
    recomputeState();
    saveData();

    modNameInput.value = "";
    modCostInput.value = "";
    modCategorySelect.value = "Engine";
    modNameInput.focus();
  });
}

// ================
// Budget input events
// ================

if (budgetInput) {
  budgetInput.addEventListener("input", () => {
    updateBudgetProgress();
    saveData();
  });
}

// ================
// Random Mod Idea Generator
// ================

const modIdeas = [
  "Upgrade to a full system exhaust for better flow and sound.",
  "Install braided steel brake lines for improved braking feel.",
  "Swap to lightweight forged wheels to reduce unsprung mass.",
  "Add adjustable rearsets for better riding ergonomics.",
  "Install a quickshifter for clutchless upshifts.",
  "Upgrade to fully adjustable front suspension.",
  "Tune the ECU for your current intake and exhaust setup.",
  "Install a steering damper for more stability at speed.",
  "Change to performance brake pads and larger rotors.",
  "Add a custom paint or wrap to match your build theme.",
];

function getRandomIdea() {
  const index = Math.floor(Math.random() * modIdeas.length);
  return modIdeas[index];
}

if (randomIdeaBtn && ideaOutput) {
  randomIdeaBtn.addEventListener("click", () => {
    const idea = getRandomIdea();
    ideaOutput.textContent = idea;

    ideaOutput.style.opacity = "0";
    requestAnimationFrame(() => {
      requestAnimationFrame(() => {
        ideaOutput.style.transition = "opacity 0.3s ease";
        ideaOutput.style.opacity = "1";
      });
    });
  });
}

// ================
// Init
// ================

loadData();
