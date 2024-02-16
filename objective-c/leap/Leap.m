#import <Foundation/Foundation.h>

# import "Leap.h"

@implementation Leap {
    NSNumber* _calendarYear;
}

- (instancetype)initWithCalendarYear:(NSNumber*)year {
    self = [super init];
    if (self) {
        _calendarYear = year;
    }
    return self;
}

- (BOOL)isLeapYear {
    if (_calendarYear.intValue % 100 == 0) {
        return _calendarYear.intValue % 400 == 0;
    } else {
        return  _calendarYear.intValue % 4 == 0;
    }
}

@end
