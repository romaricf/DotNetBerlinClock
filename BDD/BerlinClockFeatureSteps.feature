
Feature: The Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the clock should look like
"""
Y
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""


Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: At 06:06:06
When the time is "06:06:06"
Then the clock should look like
"""
Y
ROOO
ROOO
YOOOOOOOOOO
YOOO
"""

Scenario: Full third line
When the time is "04:00:01"
Then the clock should look like
"""
O
OOOO
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then there is a format error

Scenario: Not at time
When the time is "not a time"
Then there is a format error
