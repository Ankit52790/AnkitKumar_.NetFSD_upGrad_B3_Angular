"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const student_service_js_1 = require("./student.service.js");
const utils_js_1 = require("./utils.js");
// Sample data
const students = [
    { id: 1, name: "Ankit", marks: 92 },
    { id: 2, name: "Aaysha", marks: 85 },
    { id: 3, name: "Rahul", marks: 67 }
];
// Format names
console.log("Formatted Names:");
students.forEach(s => {
    console.log((0, utils_js_1.formatName)(s.name));
});
console.log("----------------------");
// Grades
console.log("Grades:");
students.forEach(s => {
    console.log(`${s.name}: ${(0, student_service_js_1.getGrade)(s.marks)}`);
});
console.log("----------------------");
// Average
const avg = (0, utils_js_1.calculateAverage)(students);
console.log("Average Marks:", avg);
console.log("----------------------");
// Topper
const topper = (0, student_service_js_1.getTopper)(students);
console.log("Topper:", topper);
