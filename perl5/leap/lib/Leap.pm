# Declare package 'Leap'
package Leap;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<is_leap_year>;

sub is_leap_year ($year) {
    return $year % 100 == 0  ? $year % 400 == 0 : $year % 4 == 0;
}
