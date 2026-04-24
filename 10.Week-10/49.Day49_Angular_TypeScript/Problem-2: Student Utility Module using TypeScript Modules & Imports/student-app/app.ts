import { Student } from "./student.model.js";
import { getGrade, getTopper } from "./student.service.js";
import { formatName, calculateAverage } from "./utils.js";

// Sample data
const students: Student[] = [
  { id: 1, name: "Ankit", marks: 92 },
  { id: 2, name: "Aaysha", marks: 85 },
  { id: 3, name: "Rahul", marks: 67 }
];

// Format names
console.log("Formatted Names:");
students.forEach(s => {
  console.log(formatName(s.name));
});

console.log("----------------------");

// Grades
console.log("Grades:");
students.forEach(s => {
  console.log(`${s.name}: ${getGrade(s.marks)}`);
});

console.log("----------------------");

// Average
const avg = calculateAverage(students);
console.log("Average Marks:", avg);

console.log("----------------------");

// Topper
const topper = getTopper(students);
console.log("Topper:", topper);
