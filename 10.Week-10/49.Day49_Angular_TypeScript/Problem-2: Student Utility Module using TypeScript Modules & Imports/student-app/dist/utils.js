"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.formatName = formatName;
exports.calculateAverage = calculateAverage;
// Capitalize name
function formatName(name) {
    return name.charAt(0).toUpperCase() + name.slice(1).toLowerCase();
}
// Calculate average marks
function calculateAverage(students) {
    const total = students.reduce((sum, s) => sum + s.marks, 0);
    return total / students.length;
}
