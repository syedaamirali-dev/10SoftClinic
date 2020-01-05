(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('apiCollection', apiCollection);
    /** @ngInject */

    function apiCollection(apiEndPoint) {
        var login = {
            validateUser: function () {
                return apiEndPoint + "UserReg/login";
            },
            studentRegister: function () {
                return apiEndPoint + "UserReg/register";
            },
            forgotPassword: () => apiEndPoint + "UserReg/forgotPassword",
            updatePassword: () => apiEndPoint + "UserReg/updatePassword",
        }

        var user = {
            getLookupData: () => {
                return apiEndPoint + "users/lookUpData"
            },
            getEnrolledCourses: () => {
                return apiEndPoint + "users/enrolledCourses";
            },
            getLessons: (slug = "") => {
                return apiEndPoint + "users/lessonsOnCourseId?courseSlug=" + slug;
            },
            // toggleLessonComplete: (lessonId, is_completed) => {
            //     return apiEndPoint + "users/toggleLessonComplete?lessonId=" + lessonId + "&is_completed=" + is_completed;
            // },
            registerCourse: (courseId) => {
                return apiEndPoint + "users/registerCourse?courseId=" + courseId;
            },

            getProfileInfo: () => {
                return apiEndPoint + "users/profile"
            },
            updateProfile: () => {
                return apiEndPoint + "users/updateProfile"
            },
            updatePassword: () => apiEndPoint + "users/updatePassword",
            // updateDp: () => apiEndPoint + "users/updateDp",
            getMenus: () => {
                return apiEndPoint + "users/menus"
            },
            getLiveCourses: () => apiEndPoint + "home/paidCourses",
            getSubscribedCourses: (paidCoursesEnrollmentId) => apiEndPoint + "users/subscribedPaidCourses?paidCoursesEnrollmentId=" + paidCoursesEnrollmentId,
            subscribeLiveCourse: () => apiEndPoint + "users/subscribePaidCourse",
            resendVerificationEmail: (paidCoursesEnrollmentId, paidCoursesId) => apiEndPoint + "users/sendPaidCourseVerificationEmail?paidCoursesEnrollmentId=" + paidCoursesEnrollmentId + "&paidCoursesId=" + paidCoursesId,
            getAllCourses: () => apiEndPoint + "users/getAllCourses",
            subscribeCourse: (id) => apiEndPoint + "users/registerCourse?courseId=" + id,

            getDashboardData: () => apiEndPoint + "users/dashboardData",

            getAdminLiveCourses: () => apiEndPoint + "users/getLiveCourses",

            // getEnrollmentDetails: (paidCoursesEnrollmentId) => apiEndPoint + "users/subscribedPaidCourses"
            getLiveEnrolements: (id = "") => apiEndPoint + "users/getPaidCourseEnrollments?studentId=" + id,
            getPaidCourseEnrollmentDetails: (id) => apiEndPoint + 'users/getPaidCourseEnrollmentDetails?paidCoursesEnrollmentId=' + id,
            updateCourseStatus: () => apiEndPoint + 'users/updateCourseStatus',
            updateDiscount: () => apiEndPoint + 'users/updateDiscount',
            addTransaction: () => apiEndPoint + 'users/addTransaction',

        }

        var admin = {
            getStudents: (id = "") => apiEndPoint + "admin/students?id=" + id,
            getCourses: (id = "") => apiEndPoint + "admin/courses?id=" + id,
            getLessons: (id = "") => apiEndPoint + "admin/lessons?id=" + id,
            saveQuiz: () => apiEndPoint + "admin/saveQuiz",
            saveLessonOrder: () => apiEndPoint + "admin/saveLessonOrder",
            togglePublishStatus: () => apiEndPoint + "admin/togglePublishStatus",
            getInstructors: (id = "") => apiEndPoint + "admin/instructors",
            saveInstructors: () => apiEndPoint + "admin/saveInstructors",
            saveCourse: () => apiEndPoint + "admin/saveCourse",
            saveLesson: () => apiEndPoint + "admin/saveLesson"
        }

        var student = {
            getLessons: (slug) => {
                return apiEndPoint + "users/lessons?courseSlug=" + slug;
            },
            markLessonComplete: (lessonId) => {
                return apiEndPoint + "users/markLessonComplete?lessonId=" + lessonId;
            },

        }
        return {
            login,
            user,
            admin,
            student
        }
    }
}());