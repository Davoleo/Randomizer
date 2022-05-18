//
//  ViewController.m
//  Randomizer-MacOS
//
//  Created by Leo Dav on 08/05/22.
//

#import "ViewController.h"

@interface ViewController()

@property (weak) IBOutlet NSNumberFormatter* formatter;

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    self.formatter.allowsFloats = NO;
    self.maxBound = 1;
    self.formatter.nilSymbol = @"1";
}

- (IBAction)generate:(NSButton *)sender {
    unsigned int generated = arc4random_uniform(self.maxBound) + 1;
    self.labelGenerated.integerValue = generated;
}


@end
