#import <Foundation/Foundation.h>

@interface Leap : NSObject

@property (nonatomic, assign, readonly) BOOL isLeapYear;

- (instancetype)initWithCalendarYear:(NSNumber*)year;

@end
