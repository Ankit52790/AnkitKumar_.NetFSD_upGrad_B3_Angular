"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getGrade = getGrade;
exports.getTopper = getTopper;
const constants_js_1 = require("./constants.js");
// Get grade
function getGrade(marks) {
    if (marks >= 90)
        return "A";
    else if (marks >= 75)
        return "B";
    else if (marks >= constants_js_1.PASS_MARKS)
        return "C";
    else
        return "Fail";
}
// Get topper
function getTopper(students) {
    return students.reduce((topper, current) => current.marks > topper.marks ? current : topper);
}
