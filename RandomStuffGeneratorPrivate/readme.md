# Project Specific Details

Some additional stuff about this project. 

# Folder Structure

* APIJSONClasses - has all the classes that will actually be used to send the data as JSON to the API calls. Consumer exposed classes.
* DatabaseClasses - has all the classes that will be used to interface with the database. Never expose to API. APIJSONClasses will use this class, get what they want. 