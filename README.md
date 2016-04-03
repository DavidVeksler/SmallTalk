# SmallTalk
Small Talk Informal Language Learning App

##App Design:

* The SmallTalk platform has three parts: an API and a web-based UI for mobile phones, and a content management system (CMS) with lesson plans.
* SmallTalk is written using Microsoft ASP.Net as a backend with a responsive HTML5 frontend using AngularJS and Bootstrap.
* SmallTalk is designed to run mainly on smartphones.  The prototype is web-based, but a native app can talk to the same API.
* The SmallTalk API/app is distinct from the English+Cultural lesson plan CMS.  Units of content in SmallTalk link to lesson plans by URL.
* This database diagram shows the things the SmallTalk tracks:
<img src="/Documentation/SmallTalkDatabase.png" />

## Key Concepts:
* Profile:  students and mentors create a **profile** which have basic demographic and **availability** information
* Lesson: an appointment to meet on a specific date and **location** to discuss a **unit**
* Unit:  a link to a lesson plan in an external CMS.  
* StudentProgres: the history of units that a student has covered.   This helps mentors know what to cover next
* Availability: a profile section with the days of week, and time of day (morning, afternoon, evening) that mentors and students can meet at.  
* Location: a list of addresses to meet up.  They are curated by the client organization.  The app tracks how many times each location is used to recommend locations for lessons.
* Lesson Rating: after each lesson, the student and teach are asked to rate each other.  There are two ratings: 
  * **Content Mastery Rating**: how well the material was learned (1-4 stars).  This is used to help mentors in future lessons
  * **Mentor/Student Review**: feedback on the mentor/student (1-4).  Review use to highlight especially good or problematic students/mentors
* Language Level: students indicate whether they are begginer, intermedia or advanced learners in their profile.

## Preview The Data
* Profiles in the DB: http://talk.fee-dev.org/profile/
* Lessons Scheduled: http://talk.fee-dev.org/lesson/


## API Documentation

* Compplete API documentation: http://talk.fee-dev.org/Help
* Each top-level object in the SmallTalk platform has a RESTful API.  For example, LessonAPI (/api/lesson)
* Example API methods:
  * List of supported languages: http://talk.fee-dev.org/api/languageAPI/
  * Lesson history for a student: http://talk.fee-dev.org/api/lesson/3/history
  * Get a single student's profile: http://talk.fee-dev.org/api/profileAPI/1
  * Get a student's ratings: http://talk.fee-dev.org/api/ratingAPI/1
  * View my academic progress: http://talk.fee-dev.org/api/profile/1/progress

## Technical Details
* The app uses ASP.Net MVC 4.6.1
* The API uses Web API 2.0 with attribute routing
* The frontend uses AngularJS+Bootstrap
* The data access layer uses Entity Framework + SQL Server
* The demo app is hosted with Amazon Web Services
* This app is designed to be easily scalable, as the frontend is static HTML files, and the API backend can be scaled to a load-balanced backend. 

## TODO's
* This prototype does not implement session security.
* An administrative backend is not included.
* A CMS for editing lesson plans is not include.  Out of the box, MediaWiki can be used to provide easy, collaborative content editing.
