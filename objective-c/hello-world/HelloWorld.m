#import <Foundation/Foundation.h>

# import "HelloWorld.h"

@implementation HelloWorld

- (NSString *)hello:(NSString *) name {
  return name == nil
    ? @"Hello, World!"
    : [NSString stringWithFormat: @"Hello, %@!", name];
}

@end
