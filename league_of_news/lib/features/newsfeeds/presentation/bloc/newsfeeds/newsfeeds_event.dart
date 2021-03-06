import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

@immutable
abstract class NewsfeedsEvent extends Equatable {}

class GetMoreData extends NewsfeedsEvent {
  final int websiteId;
  final bool clearList;

  GetMoreData(this.websiteId, {this.clearList = false});

  @override
  List<Object> get props => [websiteId, clearList];
}
