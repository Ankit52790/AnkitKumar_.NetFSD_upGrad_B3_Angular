import { Student } from "./student.model.js";
import { PASS_MARKS } from "./constants.js";

// Get grade
export function getGrade(marks: number): string {
  if (marks >= 90) 
    return "A";
  else if (marks >= 75) 
    return "B";
  else if (marks >= PASS_MARKS) 
    return "C";
  else 
    return "Fail";
}

// Get topper
export function getTopper(students: Student[]): Student {
  return students.reduce((topper, current) =>
    current.marks > topper.marks ? current : topper
  );
}