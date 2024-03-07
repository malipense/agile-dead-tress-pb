# agile-dead-tress-pb

# Context
Designing an application that likely will have to process thousands of requests, requiring at least part of the module to scale horizontally. One relational database to backup the application. One document based database or any sort of lightweight storage to store logs of events/or actions performed by the application. Any sort of messaging service able to queue notification messages to be processed at a later time. One lightweight web job to process the message queue. 
The code should be modular and event-based.

# Rationale
Event-based or event-oriented:
The goal is to maintain isolation inside the application, creating specific handlers for certain actions performed in the main module. 
